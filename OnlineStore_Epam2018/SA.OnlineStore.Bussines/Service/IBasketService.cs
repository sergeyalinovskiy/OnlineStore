namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface IBasketService
    {
        void DeleteProductInBoxById(int Id);
        void SaveProductListInBox(Basket model);
        void EditProductListInBox(Basket model);
        Basket GetProductInBox(int OrderId);
        IEnumerable<Basket> GetProductListInBox();
        void AddNewItemInBox(Basket product);
    }
}    