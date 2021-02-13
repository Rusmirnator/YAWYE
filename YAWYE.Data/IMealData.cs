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
        List<Product> AddIngredient(int id);
        Meal Recomposite(Meal meal, Product product, double weight);
        IEnumerable<Meal> FindIngredients(Meal meal);
        string AddIngredientWeight(int id, double weight, string sequence);

    }
}
