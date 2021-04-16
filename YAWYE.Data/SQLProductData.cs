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
    public class SQLProductData : IBaseRepository<Product>, IProductData
    {
        private readonly YAWYEDbContext db;

        public SQLProductData(YAWYEDbContext db)
        {
            this.db = db;
        }

        public Product Add(Product newT)
        {
            db.Set<Product>().Add(newT);

            return newT;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Product Delete(int id)
        {
            var product = db.Set<Product>().Find(id);

            if(product != null)
            {
                db.Set<Product>().Remove(product);
            }

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Set<Product>()
                .Include(p => p.MealProducts)
                .DefaultIfEmpty();
        }

        public Product GetById(int id)
        {
            return db.Set<Product>()
                .Where(p => p.ProductId == id)
                .Include(p => p.MealProducts)
                .FirstOrDefault();
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

        public Product Update(Product updatedT)
        {
            var entity = db.Set<Product>().Attach(updatedT);
            entity.State = EntityState.Modified;

            return updatedT;
        }
    }
}
