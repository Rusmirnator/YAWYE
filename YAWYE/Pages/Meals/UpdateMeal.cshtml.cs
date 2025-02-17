using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Meals
{
    public class UpdateMealModel : PageModel
    {
        private readonly IProductData productData;
        private readonly IMealData mealData;

        [BindProperty]
        public Meal Meal { get; set; }
        public Product Product { get; set; } = new Product();
        [ViewData]
        public IEnumerable<Product> Products { get; set; }
        [TempData]
        public string Message { get; set; }


        public UpdateMealModel(IProductData productData, IMealData mealData)
        {
            this.productData = productData;
            this.mealData = mealData;
        }
        public IActionResult OnGet(int? mealId)
        {

            if (mealId.HasValue)
            {
                Meal = mealData.GetById(mealId.Value);
            }
            else
            {
                Meal = new Meal();
            }
            if (Meal == null)
            {
                return RedirectToPage("./NotFound");
            }

            Products = productData.GetAll();

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Meal.MealId > 0)
            {
                mealData.Update(Meal);
            }
            else
            {
                mealData.Add(Meal);

                Meal.ImgPath = "groceries.png";
                Meal.Owner = User.Identity.Name;
            }

            mealData.Commit();

            TempData["Message"] = "Meal saved!";

            return RedirectToPage("./Details", new { mealId = Meal.MealId });

        }
    }
}
