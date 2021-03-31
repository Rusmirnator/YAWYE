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

        public T GetByIdGeneric(int id)
        {
            return db.Find<T>(id);
        }

        public T UpdateGeneric(T updatedProduct)
        {
            var entity = db.Attach<T>(updatedProduct);
            entity.State = EntityState.Modified;
            return updatedProduct;
        }
    }
}
