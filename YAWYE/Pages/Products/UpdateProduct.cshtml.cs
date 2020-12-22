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
        public Product Product { get; set; }
        

        public UpdateProductModel(IProductData productData)
        {
            this.productData = productData;
        }
        public void OnGet()
        {
        }
    }
}
