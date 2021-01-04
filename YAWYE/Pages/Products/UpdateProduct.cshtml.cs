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
    public class UpdateProductModel : PageModel
    {
        private readonly IProductData productData;
        [BindProperty]
        public Product Product { get; set; }

        public UpdateProductModel(IProductData productData)
        {
            this.productData = productData;
        }
        public IActionResult OnGet(int? productId)
        {
            if (productId.HasValue)
            {
                Product = productData.GetById(productId.Value);
            }
            else
            {
                Product = new Product();
            }
            if (Product == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Product.Id > 0)
            {
                productData.Update(Product);
            }
            else
            {
                productData.Add(Product);
            }

            productData.Commit();
            return RedirectToPage("./Details", new { productId = Product.Id });

        }
    }
}
