using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IMealProductData
    {
        decimal FindWeight(int mid, int pid);
        MealProduct AddWeight(MealProduct newMealProduct);
        MealProduct Update(MealProduct updatedMealProduct);
        MealProduct LoadLast();
        int Commit();
        MealProduct SetValues(MealProduct mp, int mid, int pid, decimal weight);
        IEnumerable<MealProduct> GetAll();
    }
}
