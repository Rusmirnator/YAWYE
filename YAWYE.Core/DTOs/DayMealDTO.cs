using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core.DTOs
{
    public class DayMealDTO
    {
        public int DayMealId { get; set; }
        [Required]
        public int DayId { get; set; }
        public Day Day { get; set; }
        [Required]
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public MealCategory Category { get; set; }
    }
}
