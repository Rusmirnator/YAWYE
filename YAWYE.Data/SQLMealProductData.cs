﻿using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace YAWYE.Data
{
    public class SQLMealProductData : IMealProductData
    {
        private readonly YAWYEDbContext db;

        public SQLMealProductData(YAWYEDbContext db)
        {
            this.db = db;
        }

        public MealProduct SetValues(MealProduct mp, int mid, int pid, decimal weight)
        {
            var ump = mp;
            ump.MealId = mid;
            ump.ProductId = pid;
            ump.ProductWeight = weight;
            return ump;
        }

        public decimal FindWeight(int mid, int pid)
        {
            var wht = from mp in db.MealProducts
                      where mp.MealId == mid && mp.ProductId == pid
                      select mp.ProductWeight;

            return wht.FirstOrDefault();
        }

        public MealProduct GetByIds(int mid, int pid)
        {
            return db.MealProducts.SingleOrDefault(mp => mp.MealId == mid && mp.ProductId == pid);
        }

    }
}
