using System;
using System.Collections.Generic;
using System.Text;

namespace YAWYE.Core
{
    public class MealProduct
    {
        public IEnumerable<MealProduct> MealProducts { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal ProductWeight { get; set; }
    }
}
