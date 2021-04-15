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
        public IEnumerable<Meal> Meals { get; set; }
        public Day Day { get; set; } = new Day();
        public Meal Meal { get; set; }
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
    }
}

