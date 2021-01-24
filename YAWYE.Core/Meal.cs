using System;
using System.Collections.Generic;
using System.Text;

namespace YAWYE.Core
{
    public class Meal
    {
        public int Id { get; set; }
        public IEnumerable<Product> MyMeal { get; set; }
        public string Name { get; set; }
        public int Kcal { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string ImgPath { get; set; }
    }
}
