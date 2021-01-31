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

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public Meal Meal { get; set; }
        [FromForm]
        public double Weight { get; set; }

        public RecalcModel(IProductData productData, IMealData mealData)
        {
            this.productData = productData;
            this.mealData = mealData;
        }
        public IActionResult OnGet(int productId, int mealId)
        {
            Product = productData.GetById(productId);
            Meal = mealData.GetById(mealId);
            return Page();
        }
        public IActionResult OnPost()
        {
            Product = productData.RecalculateNutritions(Weight, Product.Id);
            mealData.AddIngredient(Product);
            mealData.Update(Meal);
            mealData.Commit();
            return RedirectToPage("./UpdateMeal", new { mealId = Meal.Id });
        }
    }
}
