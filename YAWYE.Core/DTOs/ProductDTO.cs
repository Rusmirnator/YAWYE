﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core.DTOs
{
    public class ProductDTO
    {
        public decimal Weight { get; set; } = 100;
        [Required]
        public decimal TotalWeight { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Make { get; set; }
        [Required]
        public decimal Kcal { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fat { get; set; }
        public decimal Fiber { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public string ImgPath { get; set; }
        public bool HasImage { get; set; }
    }
}
