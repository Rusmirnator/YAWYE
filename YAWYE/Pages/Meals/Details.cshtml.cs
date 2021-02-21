using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Meals
{
    public class DetailsModel : PageModel
    {
        private readonly IMealData mealData;

        [TempData]
        public string Message { get; set; }
        public Meal Meal { get; set; }
        public ICollection<Product> Ingredients { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public DetailsModel(IMealData mealData)
        {
            this.mealData = mealData;
        }

        public IActionResult OnGet(int mealId)
        {
            Meal = mealData.GetById(mealId);

            Meals = mealData.LoadIngredients(Meal);
            
            return Page();
        }

    }
}
