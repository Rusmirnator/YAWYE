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

        public RecalcModel(IProductData productData, IMealData mealData)
        {
            this.productData = productData;
            this.mealData = mealData;
        }
        public void OnGet(int productId, int mealId)
        {
            Product = productData.GetById(productId);
            Meal = mealData.GetById(mealId);
        }
        public IActionResult OnPost(Product productRecalc)
        {
            Product = productData.RecalculateNutritions(productRecalc);
            mealData.AddIngriendient(Product);
            mealData.Update(Meal);
            mealData.Commit();
            return RedirectToPage("./Details", new { mealId = Meal.Id });
        }
    }
}
