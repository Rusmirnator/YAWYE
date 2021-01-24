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
    public class UpdateMealModel : PageModel
    {
        private readonly IMealData mealData;
        public Meal Meal { get; set; }

        public UpdateMealModel(IMealData mealData)
        {
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
                    Meal.ImgPath = "grocerydefault";
                }
                mealData.Update(Meal);
            }
            else
            {
                mealData.Add(Meal);
                Meal.ImgPath = "grocerydefault";

            }

            mealData.Commit();
            TempData["Message"] = "Product saved!";
            return RedirectToPage("./Details", new { productId = Meal.Id });

        }
    }
}
