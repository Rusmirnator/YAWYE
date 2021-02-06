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

        public Dictionary<string, double> AddIngredient(int id, double weight)
        {
            var ingredients = new Dictionary<string, double>();
            var product = db.Products.Find(id);
            ingredients.Add(product.Name, weight);
            return ingredients;

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

        public Dictionary<string, double> FindIngredients(int id)
        {
            var meal = db.Meals.Find(id);
            var ingredients = new Dictionary<string, double>();
            foreach(KeyValuePair<string,double> entry in meal.Ingredients)
            {
                ingredients.Add(entry.Key,entry.Value);
            }
            return ingredients;
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

        public Meal Recomposite(Meal meal, Product product, double weight)
        {
            var multiplier = weight / 100;
            var modMeal = meal;
            var modProd = product;
            modMeal.Kcal += modProd.Kcal * multiplier;
            modMeal.Protein += modProd.Protein * multiplier;
            modMeal.Carbohydrates += modProd.Carbohydrates * multiplier;
            modMeal.Fat += modProd.Fat * multiplier;
            modMeal.Fiber += modProd.Fiber * multiplier;
            modMeal.Price += modProd.Price * multiplier;
            modMeal.Weight += modProd.Weight * multiplier;
            return modMeal;
        }

        public Meal Update(Meal updatedMeal)
        {
            var entity = db.Meals.Attach(updatedMeal);
            entity.State = EntityState.Modified;
            return updatedMeal;
        }
    }
}
