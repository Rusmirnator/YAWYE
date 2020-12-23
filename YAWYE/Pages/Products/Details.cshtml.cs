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
    public class DetailsModel : PageModel
    {
        private readonly IProductData productData;
        public Product Product { get; set; }
        public DetailsModel(IProductData productData)
        {
            this.productData = productData;
        }

        public IActionResult OnGet(int productId)
        {
            Product = productData.GetById(productId);
            return Page();
        }
    }
}
