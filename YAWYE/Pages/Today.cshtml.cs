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
                Day = dayData.GetByDate(DateTime.Now.Date);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Day = new Day();
            }
            Meals = mealData.GetMealsByOwner(User.Identity.Name);
            return Page();
        }
        public IActionResult OnPost()
        {
            Day.Date = DateTime.Now.Date;
            return RedirectToPage("/Today");
        }

    }
}
