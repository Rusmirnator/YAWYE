using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;
using Microsoft.EntityFrameworkCore;

namespace YAWYE.Pages.Days
{
    [Authorize]
    public class TodayModel : PageModel
    {
        private readonly IDayData dayData;
        private readonly IMealData mealData;
        private readonly IDayMealData dayMealData;
        private readonly IBaseRepository<Day> baseRepository;

        public IEnumerable<Meal> Meals { get; set; }
        public IEnumerable<DayMeal> DayMeals { get; set; }
        public List<Meal> TodayMeals { get; set; } = new List<Meal>();
        public Meal Meal { get; set; }
        [BindProperty]
        public Day Day { get; set; }
        [TempData]
        public string Message { get; set; }
        public MealCategory Category { get; set; } = new MealCategory();
        public TodayModel(IDayData dayData, IMealData mealData, IDayMealData dayMealData, IBaseRepository<Day> baseRepository)
        {
            this.dayData = dayData;
            this.mealData = mealData;
            this.dayMealData = dayMealData;
            this.baseRepository = baseRepository;
        }

        public IActionResult OnGet(int? dayId)
        {
            if (dayId.HasValue)
            {
                Day = dayData.GetById(dayId.Value);
            }
            else
            {
                Day = dayData.GetByDate(DateTime.Now.Date, User.Identity.Name);
            }

            if (Day == null)
            {
                Day = new Day();
                Day.Date = DateTime.Now.Date;
                Day.OwnerName = User.Identity.Name;
            }

            TodayMeals = dayMealData
                .GetAll()
                .Where(dm => dm.DayId == Day.DayId)
                .Select(m => m.Meal)
                .ToList();

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Invalid Operation";
                return RedirectToPage("./Today");
            }
            if (Day.DayId == 0)
            {
                Day.Date = DateTime.Now.Date;
                Day.OwnerName = User.Identity.Name;
                baseRepository.Add(Day);
            }
            else
            {
                baseRepository.Update(Day);
            }
            baseRepository.Commit();

            return RedirectToPage("./Today", new { dayId = Day.DayId });
        }

    }
}
