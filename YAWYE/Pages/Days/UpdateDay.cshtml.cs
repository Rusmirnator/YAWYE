using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Days
{
    public class UpdateDayModel : PageModel
    {
        private readonly IMealData mealData;

        public UpdateDayModel(IMealData mealData)
        {
            this.mealData = mealData;
        }
        public List<Meal> Meals { get; set; }
        public void OnGet()
        {
            Meals = mealData.GetAll().ToList();
        }
    }
}
