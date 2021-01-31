using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<Meal> MyMeals { get; set; }
        public List<Product> Ingredients { get; set; }
        [Required, StringLength(60)]
        public string Name { get; set; }
        public double Kcal { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string ImgPath { get; set; }
    }
}
