using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public static class ApiRepository
    {
        public static ProductDTO ProductToDto(Product product, ProductDTO dto = null)
        {
            if(product != null)
            {
                return dto = dto ?? new ProductDTO
                {
                    ProductId = product.ProductId,
                    Weight = product.Weight,
                    TotalWeight = product.TotalWeight,
                    Name = product.Name,
                    Make = product.Make,
                    Kcal = product.Kcal,
                    Protein = product.Protein,
                    Carbohydrates = product.Carbohydrates,
                    Fat = product.Fat,
                    Fiber = product.Fiber,
                    Price = product.Price,
                    BarCode = product.BarCode,
                    ImgPath = product.ImgPath,
                    HasImage = product.HasImage,
                    MealProducts = product.MealProducts.ToList()
                };
            }
            return null;
        }
        public static Product DtoToProduct(ProductDTO product, Product ent = null)
        {
            if (product != null)
            {
                return ent = ent ?? new Product
                {
                    ProductId = product.ProductId,
                    Weight = product.Weight,
                    TotalWeight = product.TotalWeight,
                    Name = product.Name,
                    Make = product.Make,
                    Kcal = product.Kcal,
                    Protein = product.Protein,
                    Carbohydrates = product.Carbohydrates,
                    Fat = product.Fat,
                    Fiber = product.Fiber,
                    Price = product.Price,
                    BarCode = product.BarCode,
                    ImgPath = product.ImgPath,
                    HasImage = product.HasImage,
                    MealProducts = product.MealProducts.ToList()
                };
            }
            return null;
        }
        public static MealDTO MealtoDto(Meal meal, MealDTO dto = null)
        {
            if (meal != null)
            {
                return dto = dto ?? new MealDTO
                {
                    MealId = meal.MealId,
                    Name = meal.Name,
                    Kcal = meal.Kcal,
                    Protein = meal.Protein,
                    Carbohydrates = meal.Carbohydrates,
                    Fat = meal.Fat,
                    Fiber = meal.Fiber,
                    Price = meal.Price,
                    Weight = meal.Weight,
                    ImgPath = meal.ImgPath,
                    Owner = meal.Owner,
                    Category = meal.Category,
                    Products = meal.Products.ToList(),
                    MealProducts = meal.MealProducts.ToList(),
                    DayMeals = meal.DayMeals.ToList()
                };
            }
            return null;
        }
        public static Meal DtoToMeal(MealDTO meal, Meal ent = null)
        {
            if (meal != null)
            {
                return ent = ent ?? new Meal
                {
                    MealId = meal.MealId,
                    Name = meal.Name,
                    Kcal = meal.Kcal,
                    Protein = meal.Protein,
                    Carbohydrates = meal.Carbohydrates,
                    Fat = meal.Fat,
                    Fiber = meal.Fiber,
                    Price = meal.Price,
                    Weight = meal.Weight,
                    ImgPath = meal.ImgPath,
                    Owner = meal.Owner,
                    Category = meal.Category,
                    Products = meal.Products.ToList(),
                    MealProducts = meal.MealProducts.ToList(),
                    DayMeals = meal.DayMeals.ToList()
                };
            }
            return null;
        }
        public static DayDTO DayToDto(Day day, DayDTO dto = null)
        {
            if(day != null)
            {
                return dto = dto ?? new DayDTO
                {
                    DayId = day.DayId,
                    Date = day.Date,
                    OwnerName = day.OwnerName,
                    Meals = day.Meals.ToList(),
                    DayMeals = day.DayMeals.ToList()
                };
            }
            return null;
        }
        public static Day DtoToDay(DayDTO day, Day ent = null)
        {
            if (day != null)
            {
                return ent = ent ?? new Day
                {
                    DayId = day.DayId,
                    Date = day.Date,
                    OwnerName = day.OwnerName,
                    Meals = day.Meals.ToList(),
                    DayMeals = day.DayMeals.ToList()
                };
            }
            return null;
        }
        public static List<ProductDTO> ProductsToDto(List<Product> products)
        {
            var result = new List<ProductDTO>();
            var dto = new ProductDTO();
            foreach(var p in products)
            {
                dto = ProductToDto(p);
                result.Add(dto);
            }
            return result;
        }
    }
}
