﻿using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public class SQLDayMealData : IDayMealData
    {
        public DayMeal SetValues(Day day, Meal meal, MealCategory category)
        {
            return new DayMeal { Day = day, Meal = meal, Category = category, DayId = day.DayId, MealId = meal.MealId };
        }
    }
}
