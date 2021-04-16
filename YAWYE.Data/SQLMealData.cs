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

        public Meal LoadIngredients(Meal meal)
        {
            var Meal = meal;
            var query = db.Meals
                .Where(m => m.MealId == meal.MealId)
                .Include(Meal => Meal.Products)
                .ThenInclude(Meal => Meal.MealProducts).FirstOrDefault();

            return query;
        }

        public IEnumerable<Meal> GetAll()
        {
            return from m in db.Meals.Include(mp => mp.MealProducts)
                   orderby m.MealId
                   select m;
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
            return db.Meals.Where(m => m.Owner == owner).Include(dm => dm.DayMeals);
        }
    }
}
