
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;

namespace SA.OnlineStore.Bussines.Service
{
    public interface IProductService 
    {
        void DeleteProductByProductId(int Id);
        void SaveProduct(ProductModel model);
        void EditProduct(ProductModel model);
        ProductModel GetProduct(int Id);
        IEnumerable<ProductModel> GetProductLIst();
        IEnumerable<ProductModel> GetProductLIstByCategory(string category);
    }
}
