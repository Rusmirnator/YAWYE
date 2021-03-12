using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages
{
    public class TodayModel : PageModel
    {
        private readonly IMealData mealData;
        public IEnumerable<Meal> Meals { get; set; }
        public Meal Meal { get; set; }
        public TodayModel(IMealData mealData)
        {
            this.mealData = mealData;
        }

        public void OnGet()
        {
            
        }
    }
}
