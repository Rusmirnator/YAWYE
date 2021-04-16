using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public class SQLDayData : IDayData
    {
        private readonly YAWYEDbContext db;

        public SQLDayData(YAWYEDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Day> GetAllByOwner(string user)
        {
            return db.Days
                .Where(d => d.OwnerName == user)
                .Include(d => d.Meals)
                .ThenInclude(d => d.DayMeals)
                .DefaultIfEmpty();
        }

        public Day GetByDate(DateTime dt, string user)
        {
            var day = db.Days
                .Where(d => d.Date == dt && d.OwnerName == user)
                .Include(d => d.Meals).Include(d => d.Meals)
                .FirstOrDefault();

            return day;
        }

        public Day GetById(int id)
        {
            var day = db.Days
                .Where(d => d.DayId == id)
                .Include(d => d.DayMeals)
                .FirstOrDefault();

            return day;
        }

        public List<Meal> AddMeal(Meal meal, Day day = null)
        {
            var todaymeals = day.Meals.ToList() ?? new List<Meal>();
            todaymeals.Add(meal);
            return todaymeals;
        }
    }
}
