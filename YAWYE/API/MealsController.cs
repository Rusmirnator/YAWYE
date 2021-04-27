using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YAWYE.Core;
using YAWYE.Data;


namespace YAWYE.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealData mealData;

        public MealsController(IMealData mealData)
        {
            this.mealData = mealData;
        }
        public Meal Meal { get; set; }
        public MealDTO MealDTO { get; set; }
        public List<Meal> Meals { get; set; }
        public List<MealDTO> MealDTOs { get; set; }
        // GET: api/<MealsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                Meals = mealData.GetAll().ToList();

                if (!Meals.Any())
                {
                    return NotFound();
                }

                return Ok(ApiRepository.MealsToDto(Meals));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // GET api/<MealsController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Meal = mealData.GetById(id);

                if (Meal == null)
                {
                    return NotFound();
                }

                return Ok(ApiRepository.MealtoDto(Meal));
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // POST api/<MealsController>
        [HttpPost]
        public IActionResult Post(MealDTO dto)
        {
            try
            {
                Meal = ApiRepository.DtoToMeal(dto);

                mealData.Add(Meal);

                if (mealData.Commit() > 0)
                {
                    return CreatedAtAction("GetById", new { id = Meal.MealId }, Meal);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        // PUT api/<MealsController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id,MealDTO dto)
        {
            try
            {
                Meal = mealData.GetById(id);
                if (Meal == null)
                {
                    return NotFound($"Could not find meal with id:{id}");
                }

                ApiRepository.DtoToMeal(dto, Meal);
                mealData.Update(Meal);

                if (mealData.Commit() > 0)
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

        // DELETE api/<MealsController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Meal = mealData.GetById(id);

                if (Meal == null)
                {
                    return NotFound($"Could not find meal with id:{id}");
                }

                mealData.Delete(id);

                if (mealData.Commit() > 0)
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
