﻿using System;
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
        public ICollection<Meal> Meals { get; set; } 
        public ICollection<DayMeal> DayMeals { get; set; }

    }
}
