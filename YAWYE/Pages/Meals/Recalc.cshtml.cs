using System.Collections.Generic;
using System.Linq;
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
        public bool Trigger { get; set; }
        public List<Product> Products { get; set; }
        public List<CalcData> Stats { get; set; }
        public IEnumerable<Meal> Meals { get; set; }

        public RecalcModel(IProductData productData, IMealData mealData, ICalcData calcData)
        {
            this.productData = productData;
            this.mealData = mealData;
            this.calcData = calcData;
        }
        public IActionResult OnGet(int productId, int? mealId, bool trigger = false)
        {
            Trigger = trigger;

            if (!mealId.HasValue)
            {
                return RedirectToPage("./NotFound");
            }

            Meal = mealData.GetById(mealId.Value);
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
            Meals = mealData.LoadStats(Meal);
            Product = productData.GetById(productId);
            var modMeal = Meal;
            CalcData = new CalcData();

            if (Weight > 0)
            {
                MetaAddIngredientsAndStatistics(productId, mealId, Weight, modMeal);
            }
            else if (Weight == 0)
            {
                MetaRemoveIngredientsAndStatistics(mealId, productId, modMeal, CalcData);
            }

            mealData.Update(Meal);

            mealData.Commit();
            TempData["Message"] = "Meal saved!";
            return RedirectToPage("./UpdateMeal", new { mealId = Meal.MealId });
        }

        private void MetaAddIngredientsAndStatistics(int productId, int mealId, decimal Weight, Meal modMeal)
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

            Meal.Products = Products;
            Meal.CalcDatas = Stats;
        }
        private void MetaRemoveIngredientsAndStatistics(int mealId, int productId, Meal modMeal, CalcData CalcData)
        {

            CalcData = Meal.CalcDatas.Where(s => s.MealIndex == mealId && s.ProductIndex == productId).FirstOrDefault();
            Weight = calcData.FindWeight(mealId, productId);

            if (!Weight.Equals(null))
            {
                Weight *= -1;
            }
            Meal = mealData.Recomposite(modMeal, Product, Weight);
            Meal.Products.Remove(Product);
            Meal.CalcDatas.Remove(CalcData);
            calcData.Delete(CalcData.CalcDataId);

        }
    }
}
