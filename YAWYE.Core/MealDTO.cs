using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core
{
    public class MealDTO
    {
        public IEnumerable<Meal> Meals { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Kcal { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fat { get; set; }
        public decimal Fiber { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string ImgPath { get; set; }
        public string Owner { get; set; }
        public MealCategory Category { get; set; } = 0;

    }
}
