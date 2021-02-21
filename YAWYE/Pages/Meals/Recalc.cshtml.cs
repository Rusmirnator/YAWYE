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
    public class RecalcModel : PageModel
    {
        private readonly IProductData productData;
        private readonly IMealData mealData;
        private readonly ICalcData calcData;

        public Product Product { get; set; }
        public Meal Meal { get; set; }
        public decimal Weight { get; set; }
        public CalcData CalcData { get; set; }
        public int Trigger { get; set; }
        public List<Product> Products { get; set; }
        public List<CalcData> Stats { get; set; }
        public IEnumerable<Meal> Meals { get; set; }

        public RecalcModel(IProductData productData, IMealData mealData, ICalcData calcData)
        {
            this.productData = productData;
            this.mealData = mealData;
            this.calcData = calcData;
        }
        public IActionResult OnGet(int productId, int? mealId, int? trigger)
        {
            if(trigger.HasValue)
            {
                Trigger = trigger.Value;
            }
            if (mealId.HasValue)
            {
                Meal = mealData.GetById(mealId.Value);
                if(Meal.Stats != null)
                {
                    Stats = Meal.Stats.ToList();
                }
                
            }
            else
            {
                return RedirectToPage("./NotFound");
            }
            Product = productData.GetById(productId);
            

            return Page();
        }
        public IActionResult OnPost([FromRoute] int productId, [FromRoute] int mealId, [FromForm] decimal Weight)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Meal = mealData.GetById(mealId);
            Meals = mealData.LoadIngredients(Meal);
            Product = productData.GetById(productId);
            var modMeal = Meal;
            CalcData = new CalcData();

            if (Meal.ImgPath == null)
            {
                Meal.ImgPath = "grocerydefault.jpg";
            }

            if (Weight > 0)
            {

                Meal = mealData.Recomposite(modMeal, Product, Weight);
                Products = mealData.AddIngredient(productId, mealId);
                

                CalcData.MealIndex = Meal.MealId;
                CalcData.ProductIndex = Product.ProductId;
                CalcData.IngredientWeight = Weight;
                calcData.AddWeight(CalcData);
                calcData.Commit();
                CalcData = calcData.LoadLast();
                Stats = mealData.AddStat(Meal, CalcData);
                
                //calcdata add(calcdata) and then
                //meal.stats.Add(calcData);

                Meal.Products = Products;
                Meal.Stats = Stats;
                Meal.IsModified++; //developement variable, to make sure EntityState changes
            }
            else if (Weight == 0)
            {
                if (Meal.Weights != null)
                {
                    Weight *= -1;
                }
                Meal = mealData.Recomposite(modMeal, Product, Weight);
                Meal.Products.Remove(Product);
            }

            mealData.Update(Meal);

            mealData.Commit();
            TempData["Message"] = "Meal saved!";
            return RedirectToPage("./UpdateMeal", new { mealId = Meal.MealId });
        }
    }
}
