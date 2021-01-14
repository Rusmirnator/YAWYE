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

namespace YAWYE.Pages.Products
{
    public class UpdateProductModel : PageModel
    {
        private readonly IProductData productData;
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile ProductImage { get; set; }


        public UpdateProductModel(IProductData productData, IWebHostEnvironment webHostEnvironment)
        {
            this.productData = productData;
            this.webHostEnvironment = webHostEnvironment;
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
        public IActionResult OnPost(Product Product)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Product.Id > 0)
            {
                productData.Update(Product);
                Product.ImgPath = AddImageFromFile();
            }
            else
            {
                productData.Add(Product);
                Product.ImgPath = AddImageFromFile();
            }

            productData.Commit();
            TempData["Message"] = $"{Product.Name} deleted!";
            return RedirectToPage("./Details", new { productId = Product.Id });

        }
        private string AddImageFromFile()
        {
            string uniqueFileName = null;
            if (ProductImage != null)
            {
                string uploadsFolder =
                    Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + ProductImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ProductImage.CopyTo(fileStream);
                }

            }
            return uniqueFileName;
        }


    }
}
