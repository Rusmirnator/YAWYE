using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Meals
{
    public class RecalcModel : PageModel
    {
        private readonly IProductData productData;
        private readonly IMealData mealData;
        public Product Product { get; set; }
        public Meal Meal { get; set; }
        public List<Product> Products { get; set; }
        public double Weight { get; set; }

        public RecalcModel(IProductData productData, IMealData mealData)
        {
            this.productData = productData;
            this.mealData = mealData;
        }
        public IActionResult OnGet(int productId, int? mealId)
        {
            if (mealId.HasValue)
            {
                Meal = mealData.GetById(mealId.Value);
            }
            else
            {
                Meal = new Meal();
            }
            Product = productData.GetById(productId);
            
            return Page();
        }
        public IActionResult OnPost([FromRoute] int productId, [FromRoute] int mealId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Meal = mealData.GetById(mealId);

            if (Meal.Id > 0)
            {
                if (Meal.ImgPath == null)
                {
                    Meal.ImgPath = "grocerydefault.jpg";
                }
                var modProd = productData.GetById(productId);
                var modMeal = Meal;

                Meal = Recomposite(modMeal, modProd, Weight);
                Products = mealData.AddIngredient(Product);
                mealData.Update(Meal);
            }
            else
            {
                mealData.AddMeal(Meal);
                Meal.ImgPath = "grocerydefault.jpg";
                var modProd = productData.GetById(productId);
                var modMeal = Meal;
                Meal = Recomposite(modMeal, modProd, Weight);
                Products = mealData.AddIngredient(modProd);
            }
            mealData.Commit();
            TempData["Message"] = "Meal saved!";
            return RedirectToPage("./UpdateMeal", new { mealId = Meal.Id });
        }
        private Meal Recomposite(Meal meal, Product product, double weight)
        {
            var multiplier = weight / 100;
            var modMeal = meal;
            var modProd = product;
            modMeal.Kcal += modProd.Kcal * multiplier;
            modMeal.Protein += modProd.Protein * multiplier;
            modMeal.Carbohydrates += modProd.Carbohydrates * multiplier;
            modMeal.Fat += modProd.Fat * multiplier;
            modMeal.Fiber += modProd.Fiber * multiplier;
            modMeal.Price += modProd.Price * multiplier;
            modMeal.Weight += modProd.Weight * multiplier;
            return modMeal;
        }
    }
}
