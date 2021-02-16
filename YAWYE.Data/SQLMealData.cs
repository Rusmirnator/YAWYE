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

        public string AddIngredientWeight(int id, decimal weight, string sequence)
        {
            var datasequence = sequence == null ? "" : sequence;
            
            var wanted = "#" + id.ToString() +"_";
            if (!datasequence.Contains(wanted))
            {
                if (weight > 0)
                {
                    datasequence += "#" + id.ToString() + "_" + weight.ToString() + "   ";
                }
            }
            else
            {
                var start = datasequence.IndexOf(wanted);
                var chars = wanted.Length == 3 ? 6 : 7;
                datasequence = sequence.Remove(start,chars);
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
            var Meal = db.Meals
                .Where(mid => mid.MealId == id)
                .OrderBy(e => e.Name)
                .Include(e => e.Products)
                .First();

            if (Meal != null)
            {
                db.Meals.Remove(Meal);
            }
            return Meal;
        }

        public IEnumerable<Meal> FindIngredients(Meal meal)
        {
            var Meal = meal;
            var query = db.Meals
                .Include(Meal => Meal.Products).ToList();
            return query;
        }

        public decimal FindProductWeight(int id, string sequence)
        {
            decimal result = 0;
            var ids = id.ToString();
            var weight = string.Empty;
            var wanted = "#" + id.ToString() + "_";
            var datasequence = sequence;
            if(sequence.Contains(wanted))
            {
                var initialStart = sequence.IndexOf(wanted);
                var actualStart = initialStart + wanted.Length; //#1_22 #22_33 #123_23
                var end = 3;

                weight = datasequence.Substring(actualStart,end);
                result = decimal.Parse(weight);
            }

            return result;
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
    }
}
