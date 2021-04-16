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
        private readonly IBaseRepository<Meal> baseMealRepo;

        public Meal Meal { get; set; }
        public DeleteModel(IMealData mealData, IBaseRepository<Meal> baseMealRepo)
        {
            this.mealData = mealData;
            this.baseMealRepo = baseMealRepo;
        }

        public IActionResult OnGet(int mealId)
        {
            Meal = baseMealRepo.Get(mealId);
            Meal = mealData.LoadIngredients(Meal);

            if (Meal == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int mealId)
        {
            Meal = baseMealRepo.Delete(mealId);
            baseMealRepo.Commit();

            if (Meal != null)
            {
                return RedirectToPage("./MealList");
            }

            TempData["Message"] = $"{Meal.Name} deleted!";
            return RedirectToPage("./MealList");
        }
    }
}
