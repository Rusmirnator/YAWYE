using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YAWYE.Core
{
    public class Day
    {
        public int DayId { get; set; }
        public DateTime Date { get; set; }
        public string OwnerName { get; set; }
        public List<Meal> Meals { get; set; } 

    }
}
