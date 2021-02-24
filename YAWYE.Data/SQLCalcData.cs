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
                .First();

            if (CalcData != null)
            {
                db.CalcDatas.Remove(CalcData);
            }
            return CalcData;
        }

        public decimal FindWeight(int mid, int pid)
        {
            var query = from cd in db.CalcDatas
                        where cd.MealIndex == mid && cd.ProductIndex == pid
                        select cd.IngredientWeight;
            var weight = query.FirstOrDefault();
            return weight;
        }

        public CalcData GetById(int id)
        {
            var cd = db.CalcDatas.Find(id);
            return cd;
        }

        public CalcData SetValues(CalcData cd,int mid, int pid, decimal weight)
        {
            var ucd = cd;
            ucd.MealIndex = mid;
            ucd.ProductIndex = pid;
            ucd.IngredientWeight = weight;
            return ucd;
        }

        public CalcData LoadLast()
        {
            var cd = from c in db.CalcDatas
                     orderby c.CalcDataId
                     select c;
            return cd.Last();
        }

        public CalcData Update(CalcData updatedData)
        {
            var entity = db.CalcDatas.Attach(updatedData);
            entity.State = EntityState.Modified;
            return updatedData;
        }

        public IEnumerable<CalcData> GetAll()
        {
            return from cd in db.CalcDatas
                   orderby cd.CalcDataId
                   select cd;
        }
    }
}
