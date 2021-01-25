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
    public class MealListModel : PageModel
    {
        private readonly IMealData mealData;

        public MealListModel(IMealData mealData)
        {
            this.mealData = mealData;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [TempData]
        public string Message { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public void OnGet()
        {
            Meals = mealData.GetMealByName(SearchTerm);
        }
    }
}
