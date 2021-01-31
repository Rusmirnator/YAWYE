using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Meals
{
    public class DetailsModel : PageModel
    {
        private readonly IMealData mealData;
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public Meal Meal { get; set; }
        public List<Product> Ingredients { get; set; }
        public DetailsModel(IMealData mealData)
        {
            this.mealData = mealData;
        }

        public void OnGet(int mealId)
        {
            Meal = mealData.GetById(mealId);
        }
    }
}
