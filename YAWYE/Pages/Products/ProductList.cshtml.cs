using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Products
{
    [Authorize]
    public class ProductListModel : PageModel
    {
        private readonly IProductData productData;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [TempData]
        public string Message { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public ProductListModel(IProductData productData)
        {
            this.productData = productData;
        }

        public void OnGet()
        {
            Products = productData.GetProductByName(SearchTerm);
        }

    }
}
