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
    public class UpdateMealModel : PageModel
    {
        private readonly IMealData mealData;
        private readonly IProductData productData;

        [BindProperty]
        public Meal Meal { get; set; }
        public Product Product { get; set; }
        [ViewData]
        public IEnumerable<Product> Products { get; set; }


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
            if (Meal.Id > 0)
            {
                if (Meal.ImgPath == null)
                {
                    Meal.ImgPath = "grocerydefault.jpg";
                }
                mealData.Update(Meal);
            }
            else
            {
                mealData.AddMeal(Meal);
                Meal.ImgPath = "grocerydefault.jpg";
            }
            mealData.Commit();
            TempData["Message"] = "Meal saved!";
            return RedirectToPage("./Details", new { mealId = Meal.Id });

        }
    }
}
