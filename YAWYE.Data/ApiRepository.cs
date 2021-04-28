using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YAWYE.Core;
using YAWYE.Core.DTOs;

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
        public static List<MealDTO> MealsToDto(List<Meal> meals) 
        {
            var result = new List<MealDTO>();
            var dto = new MealDTO();
            foreach (var m in meals)
            {
                dto = MealtoDto(m);
                result.Add(dto);
            }
            return result;
        }
        public static MealProductDTO MealProductToDto(MealProduct product, MealProductDTO dto = null)
        {
            if (product != null)
            {
                return dto = dto ?? new MealProductDTO
                {
                    MealId = product.MealId,
                    ProductId = product.ProductId,
                    Meal = product.Meal,
                    Product = product.Product,
                    ProductWeight = product.ProductWeight,
                };
            }
            return null;
        }
        public static MealProduct DtoToMealProduct(MealProductDTO product, MealProduct ent = null)
        {
            if (product != null)
            {
                return ent = ent ?? new MealProduct
                {
                    MealId = product.MealId,
                    ProductId = product.ProductId,
                    Meal = product.Meal,
                    Product = product.Product,
                    ProductWeight = product.ProductWeight,
                };
            }
            return null;
        }

        public static DayMealDTO DayMealToDto(DayMeal product, DayMealDTO dto = null)
        {
            if (product != null)
            {
                return dto = dto ?? new DayMealDTO
                {
                    DayMealId = product.DayMealId,
                    DayId = product.DayId,
                    MealId = product.MealId,
                    Day = product.Day,
                    Meal = product.Meal,
                    Category = product.Category
                };
            }
            return null;
        }
        public static DayMeal DtoToDayMeal(DayMealDTO product, DayMeal ent = null)
        {
            if (product != null)
            {
                return ent = ent ?? new DayMeal
                {
                    DayMealId = product.DayMealId,
                    DayId = product.DayId,
                    MealId = product.MealId,
                    Day = product.Day,
                    Meal = product.Meal,
                    Category = product.Category
                };
            }
            return null;
        }
        public static List<MealProductDTO> MealProductsToDto(List<MealProduct> products)
        {
            var result = new List<MealProductDTO>();
            var dto = new MealProductDTO();
            foreach (var p in products)
            {
                dto = MealProductToDto(p);
                result.Add(dto);
            }
            return result;
        }
        public static List<DayMealDTO> DayMealsToDto(List<DayMeal> meals)
        {
            var result = new List<DayMealDTO>();
            var dto = new DayMealDTO();
            foreach (var m in meals)
            {
                dto = DayMealToDto(m);
                result.Add(dto);
            }
            return result;
        }
    }
}
