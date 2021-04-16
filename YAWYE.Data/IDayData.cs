using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IDayData : IBaseRepository<Day>
    {
        Day GetByDate(DateTime dt, string user);
        IEnumerable<Day> GetAllByOwner(string user);
    }
}
