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
    public class UpdateDayDummyPageModel : PageModel
    {
        private readonly IMealData mealData;
        private readonly IDayData dayData;

        public UpdateDayDummyPageModel(IMealData mealData, IDayData dayData)
        {
            this.mealData = mealData;
            this.dayData = dayData;
        }
        public Day Day { get; set; }
        public Meal Meal { get; set; }
        public IActionResult OnPost([FromRoute] int mealId, [FromRoute] int dayId, [FromRoute] int category)
        {
            Meal = mealData.GetById(mealId);
            Day = dayData.GetById(dayId) ?? new Day{ Meals = new List<Meal>() };
            Meal.Category = (MealCategory)category;

            Day.Meals.Add(Meal);

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

            return RedirectToPage("./UpdateDay", new { dayId = Day.DayId, category = category });
        }
    }
}
