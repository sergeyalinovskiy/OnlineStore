using SA.OnlineStore.Bussines.Entity;
using System;
using System.Collections.Generic;

namespace SA.OnlineStore.Bussines.Service
{
    public interface IProductService 
    {
        void DeleteProductByProductId(int Id);
        void SaveProduct(Product model);
        void EditProduct(Product model);
        Product GetProduct(int Id);
        IEnumerable<Product> GetProductLIst();
        IEnumerable<Product> GetProductLIstByCategory(string category);
    }
}
