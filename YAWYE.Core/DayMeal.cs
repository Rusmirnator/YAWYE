﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YAWYE.Core
{
    public class DayMeal
    {
        public int DayMealId { get; set; }
        public IEnumerable<Day> DayMeals { get; set; }
        public int DayId { get; set; }
        public Day Day { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public MealCategory Category { get; set; }

    }
}
