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
                   orderby p.Id
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

        public Product RecalculateNutritions(int id)
        {
            var thisProduct = db.Products.Find(id);
            var recalculatedProduct = new Product();
            recalculatedProduct.Kcal = thisProduct.Kcal * (recalculatedProduct.Weight / 100);
            recalculatedProduct.Protein = thisProduct.Protein * (recalculatedProduct.Weight / 100);
            recalculatedProduct.Carbohydrates = thisProduct.Carbohydrates * (recalculatedProduct.Weight / 100);
            recalculatedProduct.Fat = thisProduct.Fat * (recalculatedProduct.Weight / 100);
            recalculatedProduct.Fat = thisProduct.Fiber * (recalculatedProduct.Weight / 100);
            recalculatedProduct.Fat = thisProduct.Price * (recalculatedProduct.Weight / 100);
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
