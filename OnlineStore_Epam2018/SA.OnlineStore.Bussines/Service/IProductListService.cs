namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface IProductListService
    {
        void DeleteProductInBoxById(int Id);
        void SaveProductListInBox(ProductList model);
        void EditProductListInBox(ProductList model);
        ProductList GetProductListInBox(int Id);
        IEnumerable<ProductList> GetProductListInBox();
        void AddNewItemInBox(ProductList product);
    }
}
    