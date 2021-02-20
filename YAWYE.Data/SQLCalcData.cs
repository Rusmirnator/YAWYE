using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public class SQLCalcData : ICalcData
    {
        private readonly YAWYEDbContext db;

        public SQLCalcData(YAWYEDbContext db)
        {
            this.db = db;
        }

        public CalcData AddWeight(CalcData newData)
        {
            db.Add(newData);
            return newData;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public CalcData Delete(int id)
        {
            var CalcData = db.CalcDatas
                .Where(e => e.CalcDataId == id)
                .OrderBy(e => e.CalcDataId)
                .Include(e => e.MealIndex)
                .Include(e => e.ProductIndex)
                .First();

            if (CalcData != null)
            {
                db.CalcDatas.Remove(CalcData);
            }
            return CalcData;
        }

        public CalcData FindWeight(int CalcDataId)
        {
            throw new NotImplementedException();
        }

        public CalcData Update(CalcData updatedData)
        {
            var entity = db.CalcDatas.Attach(updatedData);
            entity.State = EntityState.Modified;
            return updatedData;
        }
    }
}
