using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages
{
    [Authorize]
    public class TodayModel : PageModel
    {
        private readonly IDayData dayData;
        private readonly IMealData mealData;

        public IEnumerable<Meal> Meals { get; set; }
        public IEnumerable<Meal> TodayMeals { get; set; }
        public Meal Meal { get; set; }
        public Day Day { get; set; }
        public TodayModel(IDayData dayData, IMealData mealData)
        {
            this.dayData = dayData;
            this.mealData = mealData;
        }

        public IActionResult OnGet()
        {
            try
            {
                Day = dayData.GetByDate(DateTime.Now.Date, User.Identity.Name);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("" + ex);
                return RedirectToPage("/Error");
            }
            finally
            {
                if(Day == null)
                {
                    Day = new Day();
                }
            }

            Meals = mealData.GetMealsByOwner(User.Identity.Name);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (Day.DayId == 0)
            {
                Day = new Day();
                Day.Date = DateTime.Now.Date;
                Day.OwnerName = User.Identity.Name;
                dayData.Add(Day);
            }
            else
            {
                dayData.Update(Day);
            }
            mealData.Commit();
            return RedirectToPage("/Today");
        }
        public async Task<Day> AddMealAsync(int mid)
        {
            var meal = mealData.GetById(mid);
            Day.Meals = dayData.AddMeal(meal);
            await Task.Run(() => dayData.Update(Day));
            return Day;
        }

    }
}
