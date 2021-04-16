using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IMealProductData : IBaseRepository<MealProduct>
    {
        MealProduct SetValues(MealProduct mp, int mid, int pid, decimal weight);
        decimal FindWeight(int mid, int pid);
        MealProduct GetByIds(int mid, int pid);

    }
}
