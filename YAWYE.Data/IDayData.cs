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
        List<Meal> AddMeal(Meal meal, Day day = null);
    }
}
