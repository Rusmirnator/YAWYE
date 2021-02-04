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
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            if (Meal.Id > 0)
            {
                if (Meal.ImgPath == null)
                {
                    Meal.ImgPath = "grocerydefault.jpg";
                }
                var modprod = Recomposite(Product, Weight);
                productData.Update(modprod);
                Products = mealData.AddIngredient(modprod);
                mealData.Update(Meal);
            }
            else
            {
                mealData.AddMeal(Meal);
                Meal.ImgPath = "grocerydefault.jpg";
                var modprod = Recomposite(Product, Weight);
                productData.Update(modprod);
                Products = mealData.AddIngredient(modprod);
            }
            mealData.Commit();
            TempData["Message"] = "Meal saved!";
            return RedirectToPage("./UpdateMeal", new { mealId = Meal.Id });
        }
        private Product Recomposite(Product product, double weight)
        {
            var multiplier = weight / 100;
            var modProd = product;
            modProd.Name = "_" + product.Name;
            modProd.Kcal *= multiplier;
            modProd.Protein *= multiplier;
            modProd.Carbohydrates *= multiplier;
            modProd.Fat *= multiplier;
            modProd.Fiber *= multiplier;
            modProd.Price *= multiplier;
            modProd.Weight *= multiplier;
            return modProd;
        }
    }
}
