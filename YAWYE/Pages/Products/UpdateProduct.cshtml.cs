using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YAWYE.Core;
using YAWYE.Data;
using YAWYE.Utilities;

namespace YAWYE.Pages.Products
{
    public class UpdateProductModel : PageModel
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProductData productData;

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }


        public UpdateProductModel(IWebHostEnvironment webHostEnvironment, IProductData productData)
        {
            this.webHostEnvironment = webHostEnvironment;
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
            if (Product.ProductId > 0)
            {
                Product.ImgPath = Product.ImgPath ?? Utilities.Utilities.AddImageFromFile(Product, webHostEnvironment.WebRootPath, Image);

                productData.Update(Product);
            }
            else
            {
                CreateProduct();
            }

            productData.Commit();

            TempData["Message"] = "Product saved!";
            return RedirectToPage("./Details", new { productId = Product.ProductId });

        }

        private void CreateProduct()
        {
            productData.Add(Product);
            Product.ImgPath = Utilities.Utilities.AddImageFromFile(Product, webHostEnvironment.WebRootPath, Image);
            RecalculatePrice();
            Product.ImgPath = Product.ImgPath ?? "gorecerydefault.jpg";
        }

        private void RecalculatePrice()
        {
            Product.Price *= Product.Price > 0 ? (100 / Product.TotalWeight) : 0;
        }


    }
}
