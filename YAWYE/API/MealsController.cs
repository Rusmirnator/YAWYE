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
    [Route("api/meals")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly YAWYEDbContext context;
        private readonly IMealData mealData;
        private readonly IProductData productData;

        public MealsController(YAWYEDbContext context, IMealData mealData, IProductData productData)
        {
            this.context = context;
            this.mealData = mealData;
            this.productData = productData;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetAll()
        {
            return await context.Meals.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetById(int id)
        {
            var meal = await context.Meals.FindAsync(id);
            if(meal == null)
            {
                return NotFound();
            }
            return meal;
        }


        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            meal = new Meal();

            mealData.AddMeal(meal);
            await context.SaveChangesAsync();
            return meal;
        }


        [HttpPut("{mid}/{pid}")]
        public async Task<ActionResult<Meal>> PutMeal(int mid, int pid)
        {
            var meal = mealData.GetById(mid);

            mealData.LoadIngredients(meal);
            mealData.AddIngredient(pid,mid);
            mealData.Update(meal);
            await context.SaveChangesAsync();

            return meal;

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            mealData.Delete(id);
        }
    }
}
