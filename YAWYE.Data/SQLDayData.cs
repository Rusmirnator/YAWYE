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
        public Day Add(Day newDay)
        {
            db.Add(newDay);
            return newDay;
        }

        public Day Delete(int id)
        {
            var day = db.Days.Where(d => d.DayId == id).Include(d => d.Meals).First();
            if(day != null)
            {
                db.Days.Remove(day);
            }
            return day;
        }

        public IEnumerable<Day> GetAllByOwner(string user)
        {
            return db.Days.Where(d => d.OwnerName == user).DefaultIfEmpty();
        }

        public Day GetByDate(DateTime dt)
        {
            var day = db.Days.Where(d => d.Date == dt).Include(d => d.Meals).FirstOrDefault();
            return day;
        }

        public Day GetById(int id)
        {
            var day = db.Days.Where(d => d.DayId == id).Include(d => d.Meals).FirstOrDefault();
            return day;
        }

        public Day Update(Day updatedDay)
        {
            var entity = db.Days.Attach(updatedDay);
            entity.State = EntityState.Modified;
            return updatedDay;
        }
        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
