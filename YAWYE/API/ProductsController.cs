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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductData productData;

        public ProductsController(IProductData productData)
        {
            this.productData = productData;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<ProductDTO> ProductsDTOs { get; set; } = new List<ProductDTO>();
        public Product Product { get; set; }


        // GET: api/<ProductsController>
        [HttpGet]
        public List<ProductDTO> GetAll()
        {
            Products = productData.GetAll().ToList();
            ProductsDTOs = ApiRepository.ProductsToDto(Products);

            return ProductsDTOs;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
        }
    }
}
