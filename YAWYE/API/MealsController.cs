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
        public ActionResult<IEnumerable<MealDTO>> GetAll()
        {
            Meals = mealData.GetAll().ToList();

            return Ok(ApiRepository.MealsToDto(Meals));
        }

        // GET api/<MealsController>/5
        [HttpGet("{id}")]
        public ActionResult<MealDTO> GetById(int id)
        {
            Meal = mealData.GetById(id);

            return Ok(ApiRepository.MealtoDto(Meal));
        }

        // POST api/<MealsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MealsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MealsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
