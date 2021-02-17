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
        public decimal Weight { get; set; }
        public int Trigger { get; set; }
        public List<Product> Products { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public string ProductWeights { get; set; }

        public RecalcModel(IProductData productData, IMealData mealData)
        {
            this.productData = productData;
            this.mealData = mealData;
        }
        public IActionResult OnGet(int productId, int? mealId, int? trigger)
        {
            if(trigger.HasValue)
            {
                Trigger = trigger.Value;
            }
            if (mealId.HasValue)
            {
                Meal = mealData.GetById(mealId.Value);
            }
            else
            {
                return RedirectToPage("./NotFound");
            }
            Product = productData.GetById(productId);

            return Page();
        }
        public IActionResult OnPost([FromRoute] int productId, [FromRoute] int mealId, [FromForm] decimal Weight)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Meal = mealData.GetById(mealId);
            Meals = mealData.FindIngredients(Meal);
            Product = productData.GetById(productId);
            var modMeal = Meal;

            if (Meal.ImgPath == null)
            {
                Meal.ImgPath = "grocerydefault.jpg";
            }

            if (Weight > 0)
            {

                Meal = mealData.Recomposite(modMeal, Product, Weight);
                Products = mealData.AddIngredient(productId, mealId);
                ProductWeights = mealData.AddIngredientWeight(productId, Weight, Meal.Weights);
                Meal.Products = Products;
                Meal.Weights = ProductWeights;
                Meal.IsModified++; //developement variable, to make sure EntityState changes
            }
            else if (Weight == 0)
            {
                if (Meal.Weights != null)
                {
                    Weight = mealData.FindProductWeight(productId, Meal.Weights);
                    Weight *= -1;
                }
                Meal = mealData.Recomposite(modMeal, Product, Weight);
                ProductWeights = mealData.AddIngredientWeight(productId, Weight, Meal.Weights);
                Meal.Weights = ProductWeights;
                Meal.Products.Remove(Product);
            }

            mealData.Update(Meal);

            mealData.Commit();
            TempData["Message"] = "Meal saved!";
            return RedirectToPage("./UpdateMeal", new { mealId = Meal.MealId });
        }
    }
}
