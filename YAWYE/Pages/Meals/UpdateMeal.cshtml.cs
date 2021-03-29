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
        public Product Product { get; set; } = new Product();
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
                        case 0:
                            ImgPath = "groceries.png";
                            break;
                        case 1:
                            ImgPath = "breakfast.png";
                            break;
                        case 2:
                            ImgPath = "lunch.png";
                            break;
                        case 3:
                            ImgPath = "dinner.png";
                            break;
                        case 4:
                            ImgPath = "supper.png";
                            break;
                        case 5:
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
                Meal.Owner = User.Identity.Name;
            }

            mealData.Commit();
            TempData["Message"] = "Meal saved!";

            return RedirectToPage("./Details", new { mealId = Meal.MealId });

        }
    }
}
