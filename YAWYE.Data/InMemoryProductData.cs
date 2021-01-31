using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public class InMemoryProductData : IProductData
    {
        public List<Product> products;
        public InMemoryProductData()
        {
            products = new List<Product>
            {
                new Product {Id = 1, Name = "Salami z czarnym pieprzem", Make = "Pilos", Kcal = 347, Protein = 25, Carbohydrates = 7, Fat = 33, Fiber = 0, BarCode = 1321075, Price = 3.50, ImgPath="https://i.iplsc.com/0009WU4LET1M2EV7-C114.jpeg"},
                new Product {Id = 2, Name = "Salami z bazylią", Make = "Pilos", Kcal = 347, Protein = 25, Carbohydrates = 7, Fat = 33, Fiber = 0, BarCode = 1231075, Price = 3.30, ImgPath="https://a.allegroimg.com/s512/111f78/d8f61b1949679a34130839af0fb3/SER-MLEKPOL-SALAMI-150G-10-sztuk"},
                new Product {Id = 3, Name = "Krakowska sucha wieprzowa", Make = "Krakus", Kcal = 174, Protein = 28, Carbohydrates = 3, Fat = 20, Fiber = 0, BarCode = 1312075, Price = 2.49, ImgPath="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcFC1OFddOq70X8VawAcNKViOfOVrvCQxOhFHqKn2lSl1esTRVCz-EErdzaSM&usqp=CAc"}
            };
        }
        public Product Add(Product newProduct)
        {
            products.Add(newProduct);
            newProduct.Id = products.Max(p => p.Id) + 1;
            return newProduct;
        }

        public string AddImageFromFile()
        {
            throw new NotImplementedException();
        }

        public Product Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            products.Remove(product);
            return product;
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

        public Product Update(Product updatedProduct)
        {
            var product = products.SingleOrDefault(p => p.Id == updatedProduct.Id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Make = updatedProduct.Make;
                product.Kcal = updatedProduct.Kcal;
                product.Protein = updatedProduct.Protein;
                product.Carbohydrates = updatedProduct.Carbohydrates;
                product.Fat = updatedProduct.Fat;
                product.Fiber = updatedProduct.Fiber;
                product.Price = updatedProduct.Price;
                product.BarCode = updatedProduct.BarCode;
            }
            return product;
        }
        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Product> GetProductByName(string name = null)
        {
            return from p in products
                   where string.IsNullOrEmpty(name) || p.Name.StartsWith(name)
                   orderby p.Name
                   select p;
        }

        public Product RecalculateNutritions(double weight, int id)
        {
            throw new NotImplementedException();
        }

        public string SetImgPath(string imagepath)
        {
            throw new NotImplementedException();
        }
    }
}
