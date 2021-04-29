using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IDayMealData : IBaseRepository<DayMeal>
    {
        DayMeal SetValues(Day day, Meal meal, MealCategory category);
        DayMeal GetByValues(int did, int mid, MealCategory cat);
        DayMeal SetValuesByIds(int did, int mid, MealCategory cat);

        IEnumerable<DayMeal> GetRelated(int did);
    }
}
