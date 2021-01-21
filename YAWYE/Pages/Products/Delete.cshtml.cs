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
        private readonly IProductData productData;
        public Product Product { get; set; }
        public DeleteModel(IProductData productData)
        {
            this.productData = productData;
        }

        public IActionResult OnGet(int productId)
        {
            Product = productData.GetById(productId);
            if (Product == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int productId)
        {
            var product = productData.Delete(productId);
            productData.Commit();
            if (Product != null)
            {
                return RedirectToPage("./ProductList");
            }
            TempData["Message"] = $"{product.Name} deleted!";
            return RedirectToPage("./ProductList");
        }
    }
}
