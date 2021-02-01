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
        public Meal Meal { get; set; }
        [ViewData]
        public Product Product { get; set; }
        [ViewData]
        public IEnumerable<Product> Ingredients { get; set; }
        public DetailsModel(IMealData mealData)
        {
            this.mealData = mealData;
        }

        public void OnGet(int mealId)
        {
            Meal = mealData.GetById(mealId);
           
        }
        public IEnumerable<Product> GetIngredientsl(Meal meal)
        {
            var productList = from i in Meal.Ingredients
                              orderby i.Name
                              select i;
            return productList;
        }
    }
}
