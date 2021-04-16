using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;


namespace YAWYE.Data
{
    public interface IProductData
    {
        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetProductByName(string name);
    }
    
}
