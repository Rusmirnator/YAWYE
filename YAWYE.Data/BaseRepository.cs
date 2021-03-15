﻿using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace YAWYE.Data
{
    public class BaseRepository<T> where T: class
    {
        private readonly YAWYEDbContext db;

        public BaseRepository(YAWYEDbContext db)
        {
            this.db = db;
        }

        public T Add(T newProduct)
        {
            db. Add<T>(newProduct);
            return newProduct;
        }


        public int Commit()
        {
            return db.SaveChanges();
        }

        public T Delete(int id)
        {
            var product = db.Find<T>(id);
            if(product != null)
            {
                db.Remove<T>(product);
            }
            return product;
        }

        //todo dokonczyc pozostale

        //public IEnumerable<Product> GetAll()
        //{
        //    return from p in db.Products.Include(mp => mp.MealProducts)
        //           orderby p.ProductId
        //           select p;
        //}

        //public Product GetById(int id)
        //{
        //    return db.Products.Find(id);
        //}

        //public IEnumerable<Product> GetProductByName(string name)
        //{
        //    var query =
        //        from p in db.Products
        //        where p.Name.StartsWith(name) || string.IsNullOrEmpty(name)
        //        orderby p.Name
        //        select p;
        //    return query;
        //}
        //public Product Update(Product updatedProduct)
        //{
        //    var entity = db.Products.Attach(updatedProduct);
        //    entity.State = EntityState.Modified;
        //    return updatedProduct;
        //}
    }
}
