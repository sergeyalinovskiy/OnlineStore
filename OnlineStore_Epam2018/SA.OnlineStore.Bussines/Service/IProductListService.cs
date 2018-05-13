namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface IProductListService
    {
        void DeleteProductInBoxById(int Id);
        void SaveProductListInBox(ProductListModel model);
        void EditProductListInBox(ProductListModel model);
        ProductListModel GetProductListInBox(int Id);
        IEnumerable<ProductListModel> GetProductListInBox();
        void AddNewItemInBox(ProductListModel product);
    }
}
    