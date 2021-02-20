using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YAWYE.Core
{
    public class CalcData
    {
        public int CalcDataId { get; set; }
        public int MealIndex { get; set; }
        public int ProductIndex { get; set; }
        public decimal IngredientWeight { get; set; }
        [ForeignKey("MealId")]
        public Product Product { get; set; }
    }
}
