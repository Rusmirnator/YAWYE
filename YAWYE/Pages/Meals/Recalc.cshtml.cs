using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Meals
{
    public class RecalcModel : PageModel
    {
        private readonly IMealData mealData;
        private readonly IMealProductData mealProductData;
        private readonly IProductData productData;

        public Product Product { get; set; }
        public Meal Meal { get; set; }
        public MealProduct MealProduct { get; set; }
        public decimal Weight { get; set; }
        public bool Trigger { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<MealProduct> MealProducts { get; set; } = new List<MealProduct>();
        public IEnumerable<Meal> Meals { get; set; }

        public RecalcModel(IMealData mealData, IMealProductData mealProductData, IProductData productData )
        {
            this.mealData = mealData;
            this.mealProductData = mealProductData;
            this.productData = productData;
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
            Meal = mealData.LoadIngredients(Meal);
            Product = productData.GetById(productId);

            MealProduct = new MealProduct();
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

            if (Meal.MealProducts != null)
            {
                MealProducts = Meal.MealProducts.ToList();
            }

            MealProduct = mealProductData.SetValues(MealProduct, mealId, productId, Weight);

            mealProductData.Add(MealProduct);
            MealProducts.Add(MealProduct);


            Meal.Products = Products;
            Meal.MealProducts = MealProducts;
            mealData.Commit();
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
