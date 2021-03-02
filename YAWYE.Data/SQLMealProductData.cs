using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace YAWYE.Data
{
    public class SQLMealProductData
    {
        private readonly YAWYEDbContext db;

        public SQLMealProductData(YAWYEDbContext db)
        {
            this.db = db;
        }

        public MealProduct AddWeight(MealProduct newMP)
        {
            db.Add(newMP);
            return newMP;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public decimal FindWeight(int mid, int pid)
        {
            var query = from mp in db.MealProducts
                        where mp.MealId == mid && mp.ProductId == pid
                        select mp.ProductId;

            return query.First();
        }

        public MealProduct SetValues(MealProduct mp, int mid, int pid, decimal weight)
        {
            var ump = mp;
            ump.MealId = mid;
            ump.ProductId = pid;
            ump.ProductWeight = weight;
            return ump;
        }

        public MealProduct LoadLast()
        {
            var mp = from mps in db.MealProducts
                     orderby mps.MealId
                     select mps;
            return mp.Last();
        }

        public MealProduct Update(MealProduct updatedMP)
        {
            var entity = db.MealProducts.Attach(updatedMP);
            entity.State = EntityState.Modified;
            return updatedMP;
        }

        public IEnumerable<MealProduct> GetAll()
        {
            return from mp in db.MealProducts
                   orderby mp.MealId
                   select mp;
        }
    }
}
