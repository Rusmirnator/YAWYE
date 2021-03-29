using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YAWYE.Core;
using YAWYE.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YAWYE.API
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly YAWYEDbContext context;
        private readonly IProductData productData;

        public ProductsController(YAWYEDbContext context, IProductData productData)
        {
            this.context = context;
            this.productData = productData;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return await context.Products.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }


        [HttpPost("{name}/{make}/(barcode)/{imgpath}/{kcal}/{protein}/{carbohydrates}/{fat}/{fiber}/{price}/{totalweight}")]
        public async Task<ActionResult<Product>> PostProduct([FromForm] string name, [FromForm] string make, [FromForm] string barcode, [FromForm] string imgpath, [FromForm] decimal kcal, [FromForm] decimal protein,
            [FromForm] decimal carbohydrates, [FromForm] decimal fat, [FromForm] decimal fiber, [FromForm] decimal price, [FromForm] decimal totalweight)
        {
            var Product = new Product { Name = name, Make = make, BarCode = barcode, ImgPath = imgpath, Kcal = kcal, Protein = protein, Carbohydrates = carbohydrates, Fat = fat, Fiber = fiber, Price = price, TotalWeight = totalweight };

            context.Add(Product);
            await context.SaveChangesAsync();
            return Product;
        }

#nullable enable
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, [FromForm] string? name, [FromForm] string? make, [FromForm] string? barcode,[FromForm] decimal? kcal, [FromForm] decimal? protein,
            [FromForm] decimal? carbohydrates, [FromForm] decimal? fat, [FromForm] decimal? fiber, [FromForm] decimal? price, [FromForm] decimal? totalweight)
        {
#nullable disable
            var product = await context.Products.FindAsync(id);
            SetProps(product,name,make,barcode,kcal,protein,carbohydrates,fat,fiber,price,totalweight);

            if (product == null)
            {
                return NotFound();
            }
            productData.Update(product);
            await context.SaveChangesAsync();

            return product;
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productData.Delete(id);
            context.SaveChanges();
        }
#nullable enable
        private Product SetProps(Product Product, string? name, string? make, string? barcode, decimal? kcal, decimal? protein,
             decimal? carbohydrates, decimal? fat, decimal? fiber, decimal? price, decimal? totalweight)
        {
            Product.Name = name ?? Product.Name;
            Product.Make = make ?? Product.Make;
            Product.BarCode = barcode ?? Product.BarCode;
            Product.Kcal = kcal != null ? (decimal)kcal : Product.Kcal;
            Product.Protein = protein != null ? (decimal)protein : Product.Protein;
            Product.Carbohydrates = carbohydrates != null ? (decimal)carbohydrates : Product.Carbohydrates;
            Product.Fat = fat != null ? (decimal)fat : Product.Fat;
            Product.Fiber = fiber != null ? (decimal)fiber : Product.Fiber;
            Product.Price = price != null ? (decimal)price : Product.Price;
            Product.TotalWeight = totalweight != null ? (decimal)totalweight : Product.TotalWeight;

            return Product;
        }
#nullable disable
    }
}
