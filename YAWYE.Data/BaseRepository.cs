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
            return null;
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public T Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Update(T updatedT)
        {
            throw new NotImplementedException();
        }
    }
}
