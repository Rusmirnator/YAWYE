using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IProductData
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Add();
        Product Update();
        Product Delete();
        Product RecalculateNutritions();
        Product AddImageFromFile();


    }
    
}
