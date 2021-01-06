using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core
{
    public class Product
    {

        public int Id { get; set; }
        public int Weight { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Make { get; set; }
        [Required]
        public int Kcal { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double Price { get; set; }
        public int BarCode { get; set; }
        public string ImgPath { get; set; }

    }
}
