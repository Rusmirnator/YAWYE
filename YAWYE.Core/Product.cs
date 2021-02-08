using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core
{
    public class Product
    {

        public int ProductId { get; set; }
        public double Weight { get; set; } = 100;
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Make { get; set; }
        [Required]
        public double Kcal { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double Price { get; set; }
        public int BarCode { get; set; }
        public string ImgPath { get; set; } 
        public bool HasImage { get; set; }

    }
}
