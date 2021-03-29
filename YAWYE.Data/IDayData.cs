using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IDayData
    {
        Day GetById(int id);
        Day GetByDate(DateTime dt, string user);
        IEnumerable<Day> GetAllByOwner(string user);
        Day Add(Day newDay);
        Day Update(Day updatedDay);
        Day Delete(int id);
        List<Meal> AddMeal(Meal meal);
    }
}
