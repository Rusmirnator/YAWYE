using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YAWYE.Core;
using YAWYE.Core.DTOs;
using YAWYE.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YAWYE.API
{
    [Authorize]
    [Route("api/meals/{mealid}/[controller]")]
    [ApiController]
    public class MealProductsController : ControllerBase
    {
        private readonly IMealProductData mealProductData;

        public MealProductsController(IMealProductData mealProductData)
        {
            this.mealProductData = mealProductData;
        }
        public MealProduct MealProduct { get; set; }
        public List<MealProduct> MealProducts { get; set; }
        public MealProductDTO MealProductDTO { get; set; }
        public List<MealProductDTO> MealProductDTOs { get; set; }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                MealProducts = mealProductData.GetAll().ToList();

                if (!MealProducts.Any())
                {
                    return NotFound();
                }

                MealProductDTOs = ApiRepository.MealProductsToDto(MealProducts);

                return Ok(MealProductDTOs);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{mid:int}/{pid:int}")]
        public IActionResult GetById(int mid, int pid)
        {
            try
            {
                MealProduct = mealProductData.GetByIds(mid, pid);

                if (MealProduct == null)
                {
                    return NotFound();
                }
                return Ok(ApiRepository.MealProductToDto(MealProduct));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [HttpPost]
        public IActionResult Post(MealProductDTO dto)
        {
            try
            {
                MealProduct = ApiRepository.DtoToMealProduct(dto);

                var exists = mealProductData.GetByIds(MealProduct.MealId, MealProduct.ProductId);

                if (exists != null)
                {
                    return BadRequest("Cannot add, entity already exists!");
                }

                mealProductData.SetValues(MealProduct, dto.MealId, dto.ProductId, dto.ProductWeight);
                mealProductData.Add(MealProduct);

                if (mealProductData.Commit() > 0)
                {
                    return CreatedAtAction("GetById", new { mid = MealProduct.MealId, pid = MealProduct.ProductId }, MealProduct);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        [HttpPut("{mid:int}/{pid:int}")]
        public IActionResult Put(int mid, int pid, MealProductDTO dto)
        {
            try
            {
                MealProduct = mealProductData.GetByIds(mid, pid);
                if (MealProduct == null)
                {
                    return NotFound($"Could not find entity with ids:{mid},{pid}");
                }

                ApiRepository.DtoToMealProduct(dto, MealProduct);
                mealProductData.Update(MealProduct);

                if (mealProductData.Commit() > 0)
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

        [HttpDelete("{mid:int}/{pid:int}")]
        public IActionResult Delete(int mid, int pid)
        {
            try
            {
                MealProduct = mealProductData.GetByIds(mid, pid);

                if (MealProduct == null)
                {
                    return NotFound($"Could not find day with ids:{mid},{pid}");
                }

                mealProductData.DeleteSpecific(MealProduct);

                if (mealProductData.Commit() > 0)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete entity");
        }
    }
}
