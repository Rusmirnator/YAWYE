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
        Dictionary<string, double> AddIngredient(int id, double weight);
        Meal Recomposite(Meal meal, Product product, double weight);
        Dictionary<string, double> FindIngredients(int id);

    }
}
