using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public class InMemoryProductData : IProductData
    {
        List<Product> products;
        public InMemoryProductData()
        {
            products = new List<Product>
            {
                new Product {Id = 1, Name = "Salami z czarnym pieprzem", Make = "Pilos", Kcal = 347, Protein = 25, Carbohydrates = 7, Fat = 33, Fiber = 0, BarCode = 1321075, Price = 3.50},
                new Product {Id = 2, Name = "Salami z bazylią", Make = "Pilos", Kcal = 347, Protein = 25, Carbohydrates = 7, Fat = 33, Fiber = 0, BarCode = 1231075, Price = 3.30},
                new Product {Id = 3, Name = "Krakowska sucha wieprzowa", Make = "Krakus", Kcal = 174, Protein = 28, Carbohydrates = 3, Fat = 20, Fiber = 0, BarCode = 1312075, Price = 2.49}
            };
        }
        public Product Add()
        {
            throw new NotImplementedException();
        }

        public Product AddImageFromFile()
        {
            throw new NotImplementedException();
        }

        public Product Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return from p in products
                   orderby p.Id
                   select p;
        }

        public Product GetById(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public Product RecalculateNutritions()
        {
            throw new NotImplementedException();
        }

        public Product Update()
        {
            throw new NotImplementedException();
        }
    }
}
