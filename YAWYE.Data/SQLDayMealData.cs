using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public class SQLDayMealData : IBaseRepository<DayMeal>, IDayMealData
    {
        private readonly YAWYEDbContext db;

        public SQLDayMealData(YAWYEDbContext db)
        {
            this.db = db;
        }

        public DayMeal Add(DayMeal newT)
        {
            db.Set<DayMeal>().Add(newT);

            return newT;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public DayMeal Delete(int id)
        {
            var dayMeal = db.Set<DayMeal>().Find(id);

            if (dayMeal != null)
            {
                db.Set<DayMeal>().Remove(dayMeal);
            }

            return dayMeal;
        }

        public IEnumerable<DayMeal> GetAll()
        {
            return db.Set<DayMeal>()
                .Include(dm => dm.Meal)
                .Include(dm => dm.Day)
                .DefaultIfEmpty();
        }

        public DayMeal GetByValues(int did, int mid, MealCategory cat)
        {
            return db.Set<DayMeal>().FirstOrDefault(dm => dm.DayId == did && dm.MealId == mid && dm.Category == cat);
        }

        public DayMeal GetById(int id)
        {
            return db.Set<DayMeal>()
                .Where(dm => dm.DayMealId == id)
                .Include(dm => dm.Day)
                .Include(dm => dm.Meal)
                .FirstOrDefault();
        }

        public DayMeal SetValues(Day day, Meal meal, MealCategory category)
        {
                return new DayMeal
                {
                    Day = day,
                    Meal = meal,
                    Category = category,
                    DayId = day.DayId,
                    MealId = meal.MealId
                };      
        }

        public DayMeal Update(DayMeal updatedT)
        {
            var entity = db.Set<DayMeal>().Attach(updatedT);
            entity.State = EntityState.Modified;

            return updatedT;
        }

        public DayMeal DeleteSpecific(DayMeal t)
        {
            var dayMeal = db.Set<DayMeal>().Find(t);

            if (dayMeal != null)
            {
                db.Set<DayMeal>().Remove(dayMeal);
            }

            return dayMeal;
        }

        public DayMeal SetValuesByIds(int did, int mid, MealCategory cat)
        {
            return new DayMeal
            {
                DayId = did,
                MealId = mid,
                Category = cat,
                Day = db.Set<Day>().Find(did),
                Meal = db.Set<Meal>().Find(mid)
            };
        }
    }
}
