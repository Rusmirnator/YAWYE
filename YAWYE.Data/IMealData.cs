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
        List<Product> AddIngredient(int pId, int mId);
        Meal Recomposite(Meal meal, Product product, decimal weight);
        IEnumerable<Meal> FindIngredients(Meal meal);
        string AddIngredientWeight(int id, decimal weight, string sequence);
        decimal FindProductWeight(int id,string sequence);

    }
}
