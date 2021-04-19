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
using YAWYE.Core.SimpleDTOs;

namespace YAWYE.Pages.Days
{
    [Authorize]
    public class TodayModel : PageModel
    {
        private readonly IDayData dayData;
        private readonly IDayMealData dayMealData;

        public IEnumerable<DayMeal> DayMeals { get; set; }
        public List<SimpleMeal> TodayMeals { get; set; } = new List<SimpleMeal>();
        public Meal Meal { get; set; }
        [BindProperty]
        public Day Day { get; set; }
        [TempData]
        public string Message { get; set; }
        public MealCategory Category { get; set; } = new MealCategory();
        public TodayModel(IDayData dayData, IDayMealData dayMealData)
        {
            this.dayData = dayData;
            this.dayMealData = dayMealData;
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
                InitializeDay();
            }

            if (Day.DayMeals.Count > 0)
            {
                PresentTodayMeals();
            }

            return Page();
        }

        private void InitializeDay()
        {
            Day = new Day();
            Day.DayMeals = new List<DayMeal>();
            Day.Date = DateTime.Now.Date;
            Day.OwnerName = User.Identity.Name;
        }

        private void PresentTodayMeals()
        {
            TodayMeals = (from m in dayMealData.GetAll()
                          where m.DayId == Day.DayId
                          select new SimpleMeal
                          {
                              Name = m.Meal.Name,
                              Kcal = m.Meal.Kcal,
                              Protein = m.Meal.Protein,
                              Carbohydrates = m.Meal.Carbohydrates,
                              Fat = m.Meal.Fat,
                              Fiber = m.Meal.Fiber,
                              Category = m.Category
                          })
                          .ToList();
        }
    }
}
