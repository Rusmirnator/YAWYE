using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;


namespace YAWYE.Data
{
    public interface IProductData : IBaseRepository<Product>
    {
        IEnumerable<Product> GetProductByName(string name);
    }
    
}
