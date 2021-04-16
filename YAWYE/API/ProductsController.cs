using Microsoft.AspNetCore.Authorization;
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
        private readonly IBaseRepository<Product> baseProdRepo;

        public ProductsController(IBaseRepository<Product> baseProdRepo)
        {
            this.baseProdRepo = baseProdRepo;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<ProductDTO> ProductsDTOs { get; set; } = new List<ProductDTO>();
        public Product Product { get; set; }
        public ProductDTO ProductDTO { get; set; }



        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAll()
        {
            Products = baseProdRepo.GetAll().ToList();

            return Ok(ApiRepository.ProductsToDto(Products));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetById(int id)
        {
            Product = baseProdRepo.Get(id);

            return Ok(ApiRepository.ProductToDto(Product));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPatch("{id}")]
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
