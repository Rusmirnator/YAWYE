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
    [Route("api/days/{dayid}/[controller]")]
    [ApiController]
    public class DayMealsController : ControllerBase
    {
        private readonly IDayMealData dayMealData;

        public DayMealsController(IDayMealData dayMealData)
        {
            this.dayMealData = dayMealData;
        }
        public DayMeal DayMeal { get; set; }
        public List<DayMeal> DayMeals { get; set; }
        public DayMealDTO DayMealDTO { get; set; }
        public List<DayMealDTO> DayMealDTOs { get; set; }
        public Day Day { get; set; }
        public Meal Meal { get; set; }



        [HttpGet]
        public IActionResult GetAll(int dayid)
        {
            try
            {
                DayMeals = dayMealData.GetRelated(dayid).ToList();

                if (!DayMeals.Any())
                {
                    return NotFound();
                }
                DayMealDTOs = ApiRepository.DayMealsToDto(DayMeals);

                return Ok(DayMealDTOs);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                DayMeal = dayMealData.GetById(id);

                if (DayMeal == null)
                {
                    return NotFound($"Could not find entity with id:{id}");
                }

                return Ok(ApiRepository.DayMealToDto(DayMeal));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpPost]
        public IActionResult Post(DayMealDTO dto)
        {
            try
            {
                DayMeal = ApiRepository.DtoToDayMeal(dto);

                var exists = dayMealData.GetById(dto.DayMealId);

                if (exists != null)
                {
                    return BadRequest("Cannot add, entity already exists!");
                }

                DayMeal = dayMealData.SetValuesByIds(dto.DayId, dto.MealId, dto.Category);

                dayMealData.Add(DayMeal);

                if (dayMealData.Commit() > 0)
                {
                    return CreatedAtAction("GetById", new { id = DayMeal.DayMealId}, DayMeal);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }


        [HttpPut("{id:int}")]
        public IActionResult Put(int id, DayMealDTO dto)
        {
            try
            {
                DayMeal = dayMealData.GetById(id);
                if (DayMeal == null)
                {
                    return NotFound($"Could not find entity with id{id}!");
                }

                ApiRepository.DtoToDayMeal(dto, DayMeal);
                dayMealData.Update(DayMeal);

                if (dayMealData.Commit() > 0)
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


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                DayMeal = dayMealData.GetById(id);

                if (DayMeal == null)
                {
                    return NotFound($"Could not find entity with id:{id}");
                }

                dayMealData.Delete(id);

                if (dayMealData.Commit() > 0)
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
