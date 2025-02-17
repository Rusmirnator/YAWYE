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
    public class DeleteModel : PageModel
    {
        private readonly IMealData mealData;

        public Meal Meal { get; set; }
        public DeleteModel(IMealData mealData)
        {
            this.mealData = mealData;
        }

        public IActionResult OnGet(int mealId)
        {
            Meal = mealData.GetById(mealId);
            Meal = mealData.LoadIngredients(Meal);

            if (Meal == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int mealId)
        {
            Meal = mealData.Delete(mealId);
            mealData.Commit();

            if (Meal != null)
            {
                return RedirectToPage("./MealList");
            }

            TempData["Message"] = $"{Meal.Name} deleted!";
            return RedirectToPage("./MealList");
        }
    }
}
