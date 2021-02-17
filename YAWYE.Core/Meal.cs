using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YAWYE.Core
{
    public class Meal
    {

        public int MealId { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Kcal { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fat { get; set; }
        public decimal Fiber { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string ImgPath { get; set; }
        public int IsModified { get; set; }
        public string Weights { get; set; }
        public enum Category
        {
                None,
                Breakfast,
                Lunch,
                Dinner,
                Supper,
                Snacks

        }
        public ICollection<Product> Products { get; set; }
        [ForeignKey("DayId")]
        public Day Day { get; set; }
    }
}
