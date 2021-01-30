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
        public IFormFile Image { get; set; }
        


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
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Product.Id > 0)
            {
                if (Product.ImgPath == null)
                {
                    Product.ImgPath = AddImageFromFile();
                }
                productData.Update(Product);
            }
            else
            {
                productData.Add(Product);
                Product.ImgPath = AddImageFromFile();

            }

            productData.Commit();
            TempData["Message"] = "Product saved!";
            return RedirectToPage("./Details", new { productId = Product.Id });

        }
        public string AddImageFromFile()
        {
            string uniqueFileName = null;
            if (Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                Image.CopyTo(fileStream);
                Product.HasImage = true;
            }
            else
            {
                uniqueFileName = "grocerydefault.jpg";
            }
            return uniqueFileName;
        }


    }
}
