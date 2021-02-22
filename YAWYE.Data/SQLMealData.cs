﻿using System.Collections.Generic;
using YAWYE.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace YAWYE.Data
{
    public class SQLMealData : IMealData
    {
        private readonly YAWYEDbContext db;

        public SQLMealData(YAWYEDbContext db)
        {
            this.db = db;
        }

        public List<Product> AddIngredient(int ProductId, int MealId)
        {
            var product = db.Products.Find(ProductId);
            var meal = db.Meals.Find(MealId);
            var Ingredients = meal.Products.ToList();
            Ingredients.Add(product);
            return Ingredients;
        }


        public Meal AddMeal(Meal newMeal)
        {
            db.Add(newMeal);
            return newMeal;
        }

        public List<CalcData> AddStat(Meal meal, CalcData stat)
        {
            var list = new List<CalcData>();
            list.Add(stat);
            return list.ToList();
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Meal Delete(int id)
        {
            var Meal = db.Meals
                .Where(mid => mid.MealId == id)
                .OrderBy(e => e.Name)
                .Include(e => e.Products)
                .Include(e => e.Stats)
                .First();

            if (Meal != null)
            {
                db.Meals.Remove(Meal);
            }
            return Meal;
        }

        public IEnumerable<Meal> LoadIngredients(Meal meal)
        {
            var Meal = meal;
            var query = db.Meals
                .Include(Meal => Meal.Products)
                .ToList();
            return query;
        }

        public IEnumerable<Meal> LoadStats(Meal meal)
        {
            var Meal = meal;
            var query = db.Meals
                .Include(Meal => Meal.Stats)
                .ToList();
            return query;
        }

        public IEnumerable<Meal> GetAll()
        {
            return from m in db.Meals
                   orderby m.MealId
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

        public Meal Recomposite(Meal meal, Product product, decimal weight)
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

        public Dictionary<string, decimal> PresentIngredients(List<Product> products, List<CalcData> statistics)
        {
            var data = new Dictionary<string, decimal>();
            for(var i = 0; i <= products.Count(); i++)
            {
                data.Add(products[i].Name, statistics[i].IngredientWeight);
            }
            return data;
        }
    }
}
