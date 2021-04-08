using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Days
{
    [Authorize]
    public class UpdateDayModel : PageModel
    {
        private readonly IMealData mealData;
        private readonly IDayData dayData;

        public UpdateDayModel(IMealData mealData, IDayData dayData)
        {
            this.mealData = mealData;
            this.dayData = dayData;
        }
        public Meal Meal { get; set; }
        public IEnumerable<Meal> Meals { get; set; } = new List<Meal>();
        [BindProperty]
        public Day Day { get; set; } = new Day();
        public DayMeal DayMeal { get; set; } = new DayMeal();
        [BindProperty]
        public MealCategory MealCategory { get; set; }
        public int Category { get; set; } 

        public IActionResult OnGet([FromRoute] int category, [FromRoute] int dayId)
        {
            Day = dayData.GetById(dayId);
            Category = category;
            Meals = mealData.GetMealsByOwner(User.Identity.Name);

            return Page();
        }
        public IActionResult OnPost([FromRoute] int mealId)
        {
            Meal = mealData.GetById(mealId);

            Day.Meals.Add(Meal);

            DayMeal.Category = MealCategory;

            Day.DayMeals.Add(DayMeal);

            return RedirectToPage("./Today", new {dayId = Day.DayId });
        }
    }
}
