namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface IProductService 
    {
        void DeleteProductByProductId(int Id);
        void SaveProduct(ProductModel model);
        void EditProduct(ProductModel model);
        ProductModel GetProduct(int Id);
        IEnumerable<ProductModel> GetProductLIst();
        IEnumerable<ProductModel> GetProductLIstByCategory(int category);
    }
}