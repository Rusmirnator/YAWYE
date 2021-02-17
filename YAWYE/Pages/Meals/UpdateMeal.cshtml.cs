using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Meals
{
    public class UpdateMealModel : PageModel
    {
        private readonly IMealData mealData;
        private readonly IProductData productData;

        [BindProperty]
        public Meal Meal { get; set; }
        public Product Product { get; set; }
        [ViewData]
        public IEnumerable<Product> Products { get; set; }
        [TempData]
        public string Message { get; set; }
        [Range(0,5)]
        public int Category { get; set; }
        public string ImgPath { get; set; }


        public UpdateMealModel(IMealData mealData, IProductData productData)
        {
            this.mealData = mealData;
            this.productData = productData;
        }
        public IActionResult OnGet(int? mealId)
        {

            if (mealId.HasValue)
            {
                Meal = mealData.GetById(mealId.Value);
            }
            else
            {
                Meal = new Meal();
            }
            if (Meal == null)
            {
                return RedirectToPage("./NotFound");
            }
            Products = productData.GetAll();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Meal.MealId > 0)
            {

                if (Meal.ImgPath == null)
                {
                    switch(Category)
                    {
                        case (int)Meal.Category.None:
                            ImgPath = "groceries.png";
                            break;
                        case (int)Meal.Category.Breakfast:
                            ImgPath = "breakfast.png";
                            break;
                        case (int)Meal.Category.Lunch:
                            ImgPath = "lunch.png";
                            break;
                        case (int)Meal.Category.Dinner:
                            ImgPath = "dinner.png";
                            break;
                        case (int)Meal.Category.Supper:
                            ImgPath = "supper.png";
                            break;
                        case (int)Meal.Category.Snacks:
                            ImgPath = "snacks.png";
                            break;
                    }
                    Meal.ImgPath = ImgPath;
                }
                mealData.Update(Meal);
            }
            else
            {
                mealData.AddMeal(Meal);
                Meal.ImgPath = "groceries.png";
            }
            mealData.Commit();
            TempData["Message"] = "Meal saved!";
            return RedirectToPage("./Details", new { mealId = Meal.MealId });

        }
    }
}
