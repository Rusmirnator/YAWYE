using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IMealData
    {
        Meal GetById(int id);
        Meal AddMeal(Meal newMeal);
        Meal Delete(int id);
        Meal Update(Meal updatedMeal);
        int Commit();
        IEnumerable<Meal> GetMealByName(string name);
        IEnumerable<Meal> GetAll();
        List<Product> AddIngredient(int pId, int mid);
        Meal Recomposite(Meal meal, Product product, decimal weight);
        Meal LoadIngredients(Meal meal);
        Dictionary<string, decimal> GetStatistics(int mid);

    }
}
