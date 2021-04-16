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
        private readonly IBaseRepository<Product> baseProdRepo;
        private readonly IBaseRepository<Meal> baseMealRepo;
        private readonly IProductData productData;

        [BindProperty]
        public Meal Meal { get; set; }
        public Product Product { get; set; } = new Product();
        [ViewData]
        public IEnumerable<Product> Products { get; set; }
        [TempData]
        public string Message { get; set; }


        public UpdateMealModel(IBaseRepository<Product> baseProdRepo, IBaseRepository<Meal> baseMealRepo, IProductData productData)
        {
            this.baseProdRepo = baseProdRepo;
            this.baseMealRepo = baseMealRepo;
            this.productData = productData;
        }
        public IActionResult OnGet(int? mealId)
        {

            if (mealId.HasValue)
            {
                Meal = baseMealRepo.Get(mealId.Value);
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
                baseMealRepo.Update(Meal);
            }
            else
            {
                baseMealRepo.Add(Meal);

                Meal.ImgPath = "groceries.png";
                Meal.Owner = User.Identity.Name;
            }

            baseMealRepo.Commit();

            TempData["Message"] = "Meal saved!";

            return RedirectToPage("./Details", new { mealId = Meal.MealId });

        }
    }
}
