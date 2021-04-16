using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Products
{
    public class DeleteModel : PageModel
    {
        public Product Product { get; set; }
        public IBaseRepository<Product> BaseProdRepo { get; }

        public DeleteModel(IBaseRepository<Product> baseProdRepo)
        {
            BaseProdRepo = baseProdRepo;
        }

        public IActionResult OnGet(int productId)
        {
            Product = BaseProdRepo.Get(productId);
            if (Product == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int productId)
        {
            var product = BaseProdRepo.Delete(productId);
            BaseProdRepo.Commit();

            if (Product != null)
            {
                return RedirectToPage("./ProductList");
            }
            TempData["Message"] = $"{product.Name} deleted!";
            return RedirectToPage("./ProductList");
        }
    }
}
