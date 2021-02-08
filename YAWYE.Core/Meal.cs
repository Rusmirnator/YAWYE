using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YAWYE.Core
{
    public class Meal
    {
        
        public int Id { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public List<Product> Ingredients { get; set; }
        [Required]
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
