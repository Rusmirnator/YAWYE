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
        private readonly IMealProductData mealProductData;

        public Product Product { get; set; }
        public Meal Meal { get; set; }
        public MealProduct MealProduct { get; set; }
        public decimal Weight { get; set; }
        public bool Trigger { get; set; }
        public List<Product> Products { get; set; }
        public List<MealProduct> MealProducts { get; set; }
        public IEnumerable<Meal> Meals { get; set; }

        public RecalcModel(IProductData productData, IMealData mealData, IMealProductData mealProductData)
        {
            this.productData = productData;
            this.mealData = mealData;
            this.mealProductData = mealProductData;
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
            MealProducts = new List<MealProduct>();
            Product = productData.GetById(productId);
            var modMeal = Meal;

            if (Weight > 0)
            {
                MetaAddIngredientsAndStatistics(productId, mealId, Weight, modMeal);
            }
            else if (Weight == 0)
            {
                MetaRemoveIngredientsAndStatistics(mealId, productId, modMeal);
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
            MealProduct = mealProductData.SetValues(MealProduct, mealId, productId, Weight);

            mealProductData.Add(MealProduct);
            MealProducts.Add(MealProduct);


            Meal.Products = Products;
            Meal.MealProducts = MealProducts;
        }
        private void MetaRemoveIngredientsAndStatistics(int mealId, int productId, Meal modMeal)
        {

            Weight = mealProductData.FindWeight(mealId, productId);

            MealProduct = mealProductData.GetByIds(mealId, productId);

            if (!Weight.Equals(null))
            {
                Weight *= -1;
            }
            Meal = mealData.Recomposite(modMeal, Product, Weight);
            Meal.Products.Remove(Product);
            Meal.MealProducts.Remove(MealProduct);

        }
    }
}
