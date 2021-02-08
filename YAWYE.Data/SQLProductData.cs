using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace YAWYE.Data
{
    public class SQLProductData : IProductData
    {
        private readonly YAWYEDbContext db;

        public SQLProductData(YAWYEDbContext db)
        {
            this.db = db;
        }

        public Product Add(Product newProduct)
        {
            db.Add(newProduct);
            return newProduct;
        }


        public int Commit()
        {
            return db.SaveChanges();
        }

        public Product Delete(int id)
        {
            var product = GetById(id);
            if(product != null)
            {
                db.Products.Remove(product);
            }
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return from p in db.Products
                   orderby p.ProductId
                   select p;
        }

        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            var query =
                from p in db.Products
                where p.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby p.Name
                select p;
            return query;
        }

        public Product RecalculateNutritions(double weight, int id)
        {
            var recalculatedProduct = db.Products.Find(id);
            var multiplier = weight / 100;
            recalculatedProduct.Kcal *= multiplier;
            recalculatedProduct.Protein *= multiplier;
            recalculatedProduct.Carbohydrates *= multiplier;
            recalculatedProduct.Fat *= multiplier;
            recalculatedProduct.Fiber *= multiplier;
            recalculatedProduct.Price *= multiplier;
            recalculatedProduct.Weight *= multiplier;
            return recalculatedProduct;

        }
        public Product Update(Product updatedProduct)
        {
            var entity = db.Products.Attach(updatedProduct);
            entity.State = EntityState.Modified;
            return updatedProduct;
        }
    }
}
