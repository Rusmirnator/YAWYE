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
        List<CalcData> AddStat(Meal meal, CalcData cd);
        Meal Recomposite(Meal meal, Product product, decimal weight);
        IEnumerable<Meal> LoadIngredients(Meal meal);
        IEnumerable<Meal> LoadStats(Meal meal);
        Dictionary<string, decimal> GetStatistics(IEnumerable<Product> products, IEnumerable<CalcData> statistics);


    }
}
