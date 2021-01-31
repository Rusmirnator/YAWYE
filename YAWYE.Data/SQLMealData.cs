using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace YAWYE.Data
{
    public class SQLMealData : IMealData
    {
        private readonly YAWYEDbContext db;

        public SQLMealData(YAWYEDbContext db)
        {
            this.db = db;
        }

        public List<Product> AddIngredient(Product product)
        {
            List<Product> Ingredients = new List<Product>();
            Ingredients.Add(product);
            return Ingredients;
        }

        public Meal AddMeal(Meal newMeal)
        {
            db.Add(newMeal);
            return newMeal;
        }


        public int Commit()
        {
            return db.SaveChanges();
        }

        public Meal Delete(int id)
        {
            var meal = GetById(id);
            if (meal != null)
            {
                db.Meals.Remove(meal);
            }
            return meal;
        }

        public IEnumerable<Meal> GetAll()
        {
            return from m in db.Meals
                   orderby m.Id
                   select m;
        }

        public Meal GetById(int id)
        {
            return db.Meals.Find(id);
        }

        public IEnumerable<Meal> GetMealByName(string name)
        {
            var query =
            from m in db.Meals
            where m.Name.StartsWith(name) || string.IsNullOrEmpty(name)
            orderby m.Name
            select m;
            return query;
        }

        public Meal RecalculateNutriotions(int id)
        {
            throw new NotImplementedException();
        }

        public Meal Update(Meal updatedMeal)
        {
            var entity = db.Meals.Attach(updatedMeal);
            entity.State = EntityState.Modified;
            return updatedMeal;
        }
    }
}
