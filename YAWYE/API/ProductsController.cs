using Microsoft.AspNetCore.Mvc;
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
        public Product Product { get; set; } = new Product();
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return context.Products.SingleOrDefault(p => p.ProductId == id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public Product CreateNew([FromForm] string name, [FromForm] string make, [FromForm] string barcode, [FromForm] string imgpath, [FromForm] decimal kcal, [FromForm] decimal protein,
            [FromForm] decimal carbohydrates, [FromForm] decimal fat, [FromForm] decimal fiber, [FromForm] decimal price, [FromForm] decimal totalweight)
        {
            Product = new Product { Name = name, Make = make, BarCode = barcode, ImgPath = imgpath, Kcal = kcal, Protein = protein, Carbohydrates = carbohydrates, Fat = fat, Fiber = fiber, Price = price, TotalWeight = totalweight };
            context.Add(Product);
            context.SaveChanges();
            return Product;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productData.Delete(id);
            context.SaveChanges();
        }
    }
}
