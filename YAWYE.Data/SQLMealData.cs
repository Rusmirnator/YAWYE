using System.Collections.Generic;
using YAWYE.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace YAWYE.Data
{
    public class SQLMealData : IBaseRepository<Meal>, IMealData
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

        public Meal LoadIngredients(Meal meal)
        {
            var Meal = meal;
            var query = db.Meals
                .Where(m => m.MealId == meal.MealId)
                .Include(Meal => Meal.Products)
                .ThenInclude(Meal => Meal.MealProducts).FirstOrDefault();

            return query;
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

        public IEnumerable<Meal> GetMealsByOwner(string owner)
        {
            return db.Meals
                .Where(m => m.Owner == owner)
                .Include(dm => dm.DayMeals);
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

        public Meal GetById(int id)
        {
            return db.Set<Meal>()
                .Where(m => m.MealId == id)
                .Include(m => m.MealProducts)
                .FirstOrDefault();
        }

        public IEnumerable<Meal> GetAll()
        {
            return db.Set<Meal>()
                .Include(m => m.MealProducts)
                .DefaultIfEmpty();
        }

        public Meal Add(Meal newT)
        {
            db.Set<Meal>().Add(newT);

            return newT;
        }

        public Meal Update(Meal updatedT)
        {
            var entity = db.Set<Meal>().Attach(updatedT);
            entity.State = EntityState.Modified;

            return updatedT;
        }

        public Meal Delete(int id)
        {
            var meal = db.Set<Meal>().Find(id);

            if (meal != null)
            {
                db.Set<Meal>().Remove(meal);
            }

            return meal;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Meal DeleteSpecific(Meal t)
        {
            var meal = db.Set<Meal>().Find(t);

            if (meal != null)
            {
                db.Set<Meal>().Remove(meal);
            }

            return meal;
        }
    }
}
