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

        public List<Product> AddIngredient(int ProductId)
        {
            var product = db.Products.Find(ProductId);
            var Ingredients = new List<Product>();
            Ingredients.Add(product);
            return Ingredients;
        }

        public string AddIngredientWeight(int id, double weight, string sequence)
        {
            var datasequence = sequence;
            var a = 0;
            var b = 0;

            if (weight > 0)
            {
                datasequence += id.ToString() + "_" + weight.ToString() + " ";
            }
            else
            {
                for (var i = 0; i < datasequence.Length; i++)
                {
                    if (datasequence[i].Equals(id.ToString()[i]) && datasequence[i + 1].Equals(id.ToString()[i + 1]))
                    {
                        a = i;
                        b = i + 6;
                    }
                }
                datasequence.Remove(a, b);
            }
            return datasequence;
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

        public IEnumerable<Meal> FindIngredients(Meal meal)
        {
            var Meal = meal;
            var query = db.Meals
                .Include(Meal => Meal.Products).ToList();
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
