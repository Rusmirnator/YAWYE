using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Meals
{
    public class DetailsModel : PageModel
    {
        private readonly IMealData mealData;
        private readonly ICalcData calcData;

        [TempData]
        public string Message { get; set; }
        public Meal Meal { get; set; }
        public IEnumerable<Product> Ingredients { get; set; }
        public IEnumerable<CalcData> Stats { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public CalcData CalcData { get; set; }
        public Dictionary<string, decimal> Statistics { get; set; }
        public DetailsModel(IMealData mealData, ICalcData calcData)
        {
            this.mealData = mealData;
            this.calcData = calcData;
        }

        public IActionResult OnGet(int mealId)
        {
            Meal = mealData.GetById(mealId);
            Meals = mealData.LoadIngredients(Meal);

            Ingredients = Meal.Products.ToList();

            Meals = mealData.LoadStats(Meal);

            Stats = calcData.GetAll();

            Statistics = mealData.GetStatistics(Ingredients, Stats);
            return Page();
        }
    }
}
