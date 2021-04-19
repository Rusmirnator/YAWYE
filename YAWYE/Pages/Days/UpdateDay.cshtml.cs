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
        public bool IsRemoved { get; set; }
        public IActionResult OnGet(int category, int dayId, bool isremoved = false)
        {
            IsRemoved = isremoved;
            Category = category;
            DayId = dayId;

            if (dayId != 0)
            {
                Day = dayData.GetById(dayId);
            }

            if (IsRemoved)
            {
                Meals = (from m in dayMealData.GetAll()
                         where m.DayId == Day.DayId && m.Category == (MealCategory)Category
                         select m.Meal)
                         .ToList();
            }
            else
            {
                Meals = mealData.GetMealsByOwner(User.Identity.Name);
            }

            return Page();
        }
        public IActionResult OnPostProcessMeal(int mealId, [FromRoute] int dayId, [FromRoute] int category,[FromRoute] bool? isremoved = false)
        {
            IsRemoved = isremoved.Value;

            Meal = mealData.GetById(mealId);
            Day = dayData.GetById(dayId) ?? new Day { DayMeals = new List<DayMeal>() };

            if (!IsRemoved)
            {
                DayMeal = dayMealData.SetValues(Day, Meal, (MealCategory)category);

                Day.DayMeals.Add(DayMeal);

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

                TempData["Message"] = $"{Meal.Name} added to {(MealCategory)category}";
            }
            else
            {
                DayMeal = dayMealData.GetByValues(dayId,mealId,(MealCategory)category);

                Day.DayMeals.Remove(DayMeal);

                TempData["Message"] = $"{Meal.Name} removed from {(MealCategory)category}";
            }

            dayData.Commit();



            return RedirectToPage("./Today", new { dayId = Day.DayId });
        }
    }
}

