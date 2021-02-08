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
        public double Weight { get; set; }
        public string Products { get; set; }

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
                return RedirectToPage("./NotFound");
            }
            Product = productData.GetById(productId);

            return Page();
        }
        public IActionResult OnPost([FromRoute] int productId, [FromRoute] int mealId, [FromForm] double Weight)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Meal = mealData.GetById(mealId);

            if (Meal.ImgPath == null)
            {
                Meal.ImgPath = "grocerydefault.jpg";
            }
            Product = productData.GetById(productId);
            var modMeal = Meal;
            if (Weight > 0)
            {
                Meal = mealData.Recomposite(modMeal, Product, Weight);
                //Products = mealData.AddIngredient(productId, Weight);
                //Meal.Ingredients += Products;
            }
            mealData.Update(Meal);

            mealData.Commit();
            TempData["Message"] = "Meal saved!";
            return RedirectToPage("./UpdateMeal", new { mealId = Meal.Id });
        }
    }
}
