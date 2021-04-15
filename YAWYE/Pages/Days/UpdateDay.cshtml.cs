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
        private readonly IDayMealData dayMealData;

        public UpdateDayModel(IMealData mealData, IDayData dayData, IDayMealData dayMealData)
        {
            this.mealData = mealData;
            this.dayData = dayData;
            this.dayMealData = dayMealData;
        }
        public IEnumerable<Meal> Meals { get; set; }
        public Day Day { get; set; } = new Day();
        public Meal Meal { get; set; }
        public DayMeal DayMeal { get; set; } = new DayMeal();
        [BindProperty]
        public int Category { get; set; }
        [BindProperty]
        public int DayId { get; set; }
        public IActionResult OnGet(int category, int dayId)
        {
            Category = category;
            DayId = dayId;
            if (dayId != 0)
            {
                Day = dayData.GetById(dayId);
            }

            Meals = mealData.GetMealsByOwner(User.Identity.Name);

            return Page();
        }
        public IActionResult OnPostAddMeal(int mealId, [FromRoute] int dayId, [FromRoute] int category)
        {

            Meal = mealData.GetById(mealId);
            Day = dayData.GetById(dayId) ?? new Day { Meals = new List<Meal>(), DayMeals = new List<DayMeal>() };

            DayMeal = dayMealData.SetValues(Day, Meal, (MealCategory)category);

            
            //Day.DayMeals.Add(DayMeal);

            if (Day.DayId == 0)
            {
                Day.OwnerName = User.Identity.Name;
                Day.Date = DateTime.Now.Date;
                dayData.Add(Day);
            }
            else
            {
                Day = dayData.GetById(dayId);
                dayData.Update(Day);
            }


            mealData.Commit();

            return RedirectToPage("./Today", new { dayId = Day.DayId });
        }
    }
}

