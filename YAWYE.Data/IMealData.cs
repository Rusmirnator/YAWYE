using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IMealData : IBaseRepository<Meal>
    {
        IEnumerable<Meal> GetMealByName(string name);
        List<Product> AddIngredient(int pId, int mid);
        Meal LoadIngredients(Meal meal);
        Dictionary<string, decimal> GetStatistics(int mid);
        IEnumerable<int> GetRelatedById(int mid);
        IEnumerable<Meal> GetMealsByOwner(string owner);
        Meal Recomposite(Meal meal, Product product, decimal weight);

    }
}
