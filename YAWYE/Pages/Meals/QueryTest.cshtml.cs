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
    public class QueryTestModel : PageModel
    {
        private readonly IMealData mealData;

        public QueryTestModel(IMealData mealData)
        {
            this.mealData = mealData;
        }
        public Meal Meal { get; set; }
        public IEnumerable<Meal> Ingredients { get; set; }
        [ViewData]
        public Dictionary<int,decimal> Result { get; set; }
        public IActionResult OnGet(int mealId)
        {
            Meal = mealData.GetById(mealId);
            Ingredients = mealData.LoadIngredients(Meal);
            mealData.LoadStats(Meal);

            var query2 = from i in Meal.CalcDatas
                        select i.IngredientWeight;

            var query = from id in Meal.CalcDatas
                         select id.ProductIndex;

            var result = new Dictionary<int, decimal>();

            result.Add(query.First(), query2.First());

            Result = result;

            return Page();
        }
    }
}
