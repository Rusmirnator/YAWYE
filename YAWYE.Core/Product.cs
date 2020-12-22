using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Make { get; set; }
        [Required]
        public int Kcal { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fat { get; set; }
        public int Fiber { get; set; }
        public int Price { get; set; }

    }
}
