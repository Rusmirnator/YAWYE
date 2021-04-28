using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core.DTOs
{
    public class MealProductDTO
    {
        [Required]
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public decimal ProductWeight { get; set; }
    }
}
