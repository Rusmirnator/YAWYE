using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IDayData
    {
        public Day GetById(int id);
        public Day GetByDate(DateTime dt);
        public IEnumerable<Day> GetAllByOwner(string user);
        public Day Add(Day newDay);
        public Day Update(Day updatedDay);
        public Day Delete(int id);



    }
}
