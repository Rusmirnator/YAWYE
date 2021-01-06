using System;
using System.Collections.Generic;
using System.Text;

namespace YAWYE.Core
{
    public class Meal
    {
        public int Id { get; set; }
        public IEnumerable<Product> MyMeal { get; set; }
    }
}
