using System;
using System.Collections.Generic;
using System.Text;

namespace YAWYE.Data
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T newT);
        T Update(T updatedT);
        T Delete(int id);
        int Commit();

    }
}
