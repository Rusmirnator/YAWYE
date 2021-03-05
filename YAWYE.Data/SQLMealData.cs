using System.Collections.Generic;
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

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Meal Delete(int id)
        {
            var Meal = db.Meals.Where(m => m.MealId == id).Include(m => m.Products).First();
            if (Meal != null)
            {
                db.Meals.Remove(Meal);
            }
            return Meal;
        }

        public Meal LoadIngredients(Meal meal)
        {
            var Meal = meal;
            var query = db.Meals
                .Where(m => m.MealId == meal.MealId)
                .Include(Meal => Meal.Products)
                .ThenInclude(Meal => Meal.MealProducts).First();
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
            modMeal.Price += modProd.Price * (modProd.Price > 0 ? multiplier : 1);
            modMeal.Weight += modProd.Weight * multiplier;
            return modMeal;
        }

        public Meal Update(Meal updatedMeal)
        {
            var entity = db.Meals.Attach(updatedMeal);
            entity.State = EntityState.Modified;
            return updatedMeal;
        }

        public Dictionary<string, decimal> GetStatistics(int mid)
        {
            var query = from n in db.Products
                        join w in db.MealProducts on n.ProductId equals w.ProductId
                        where w.MealId == mid && w.ProductId == n.ProductId
                        select new { Name = n.Name, Weight = w.ProductWeight };


            var result = query.ToDictionary(n => n.Name, w => w.Weight);

            return result;
        }
        public IEnumerable<int> GetRelatedById(int mid)
        {
            var query = from i in db.MealProducts
                        where i.MealId == mid
                        select i.ProductId;

            return query;
        }
    }
}
