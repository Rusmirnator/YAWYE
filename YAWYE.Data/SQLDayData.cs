using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public class SQLDayData : IBaseRepository<Day>, IDayData
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
                .Include(d => d.DayMeals)
                .FirstOrDefault();

            return day;
        }
        public Day GetById(int id)
        {
            return db.Set<Day>()
                .Where(d => d.DayId == id)
                .Include(d => d.DayMeals)
                .FirstOrDefault();
        }

        public IEnumerable<Day> GetAll()
        {
            return db.Set<Day>()
                .Include(d => d.DayMeals)
                .DefaultIfEmpty();
        }

        public Day Add(Day newT)
        {
            db.Set<Day>().Add(newT);

            return newT;
        }

        public Day Update(Day updatedT)
        {
            var entity = db.Set<Day>().Attach(updatedT);
            entity.State = EntityState.Modified;

            return updatedT;
        }

        public Day Delete(int id)
        {
            var day = db.Set<Day>().Find(id);

            if (day != null)
            {
                db.Set<Day>().Remove(day);
            }

            return day;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
