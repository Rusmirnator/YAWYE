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
        Product Add(Product newProduct);
        Product Update(Product updatedProduct);
        Product Delete(int id);
        Product RecalculateNutritions(Product recalculatedProduct);
        Product AddImageFromFile();
        public int Commit();
        IEnumerable<Product> GetProductByName(string name);
    }
    
}
