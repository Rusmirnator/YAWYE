using System;
using System.Collections.Generic;
using System.Text;

namespace YAWYE.Core
{
    public class DayDTO
    {
        public int DayId { get; set; }
        public DateTime Date { get; set; }
        public string OwnerName { get; set; }
        public List<Meal> Meals { get; set; }
        public List<DayMeal> DayMeals { get; set; }

    }
}
