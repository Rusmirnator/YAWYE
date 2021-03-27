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
    public class BaseRepository<T> where T : class
    {
        private readonly YAWYEDbContext db;

        public BaseRepository(YAWYEDbContext db)
        {
            this.db = db;
        }

        public T Add(T newProduct)
        {
            db.Add<T>(newProduct);
            return newProduct;
        }


        public int Commit()
        {
            return db.SaveChanges();
        }

        public T Delete(int id)
        {
            var product = db.Find<T>(id);
            if (product != null)
            {
                db.Remove<T>(product);
            }
            return product;
        }

        public T GetById(int id)
        {
            return db.Find<T>(id);
        }

        public T Update(T updatedProduct)
        {
            var entity = db.Attach<T>(updatedProduct);
            entity.State = EntityState.Modified;
            return updatedProduct;
        }
        public Product SetProps(string name, string make, string barcode, string imgpath, decimal kcal, decimal protein,
            decimal carbohydrates, decimal fat, decimal fiber, decimal price, decimal totalweight)
        {
            var newProduct = new Product { Name = name, Make = make, BarCode = barcode, ImgPath = imgpath, Kcal = kcal, Protein = protein, Carbohydrates = carbohydrates, Fat = fat, Fiber = fiber, Price = price, TotalWeight = totalweight };
            return newProduct;
        }
    }
}
