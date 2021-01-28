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
        Meal RecalculateNutriotions(int id);
        int Commit();
        IEnumerable<Meal> GetMealByName(string name);
        IEnumerable<Meal> GetAll();

    }
}
