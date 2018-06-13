namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface IProductService 
    {
        void DeleteProductByProductId(int Id);
        bool SaveProduct(Product model);
        void EditProduct(Product model);
        Product GetProduct(int Id);
        IEnumerable<Product> GetProductLIst();
        IEnumerable<Product> GetProductLIstByCategory(int category);
        List<Product> SearchProducts(string name, int category, int minValue, int maxValue);
    }
}