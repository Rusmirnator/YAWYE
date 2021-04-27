using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
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
        public ProductDTO ProductDTO { get; set; }



        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                Products = productData.GetAll().ToList();

                if(!Products.Any())
                {
                    return NotFound();
                }

                return Ok(ApiRepository.ProductsToDto(Products));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id:int}")]
        public ActionResult<ProductDTO> GetById(int id)
        {
            try
            {
                Product = productData.GetById(id);

                if (Product == null)
                {
                    return NotFound();
                }

                return Ok(ApiRepository.ProductToDto(Product));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post(ProductDTO dto)
        {
            try
            {
                Product = ApiRepository.DtoToProduct(dto);

                productData.Add(Product);

                if (productData.Commit() > 0)
                {
                    return CreatedAtAction("GetById", new { id = Product.ProductId }, Product);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, ProductDTO dto)
        {
            try
            {
                Product = productData.GetById(id);
                if (Product == null)
                {
                    return NotFound($"Could not find product with id:{id}");
                }

                ApiRepository.DtoToProduct(dto, Product);
                productData.Update(Product);

                if (productData.Commit() > 0)
                {
                    return Ok("Updated!");
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Product = productData.GetById(id);

                if (Product == null)
                {
                    return NotFound($"Could not find product with id:{id}");
                }

                productData.Delete(id);

                if (productData.Commit() > 0)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }
    }
}
