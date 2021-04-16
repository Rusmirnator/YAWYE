using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public class SQLDayMealData : IDayMealData
    {
        private readonly YAWYEDbContext db;

        public SQLDayMealData(YAWYEDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<DayMeal> GetAll()
        {
            return db.DayMeals.Include(dm => dm.Meal);
        }

        public DayMeal SetValues(Day day, Meal meal, MealCategory category)
        {
            return new DayMeal { Day = day, Meal = meal, Category = category, DayId = day.DayId, MealId = meal.MealId };
        }
    }
}
