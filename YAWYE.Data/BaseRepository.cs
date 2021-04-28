using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace YAWYE.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly YAWYEDbContext context;

        public BaseRepository(YAWYEDbContext context)
        {
            this.context = context;
        }


        public T Add(T newT)
        {
            context.Add<T>(newT);
            return newT;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public T Delete(int id)
        {
            var entity = context.Set<T>().Find(id);

            if(entity != null)
            {
                context.Set<T>().Remove(entity);
            }

            return entity;
        }
        public T DeleteSpecific(T deleteT)
        {
            var entity = context.Set<T>().Find(deleteT);

            if (entity != null)
            {
                context.Set<T>().Remove(entity);
            }

            return entity;
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().Include(t => t);
        }

        public T Update(T updatedT)
        {
            var entity = context.Set<T>().Attach(updatedT);
            entity.State = EntityState.Modified;
            return updatedT;
        }
    }
}
