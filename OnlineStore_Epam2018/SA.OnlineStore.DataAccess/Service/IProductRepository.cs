namespace SA.OnlineStore.DataAccess.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface IProductRepository
    {
        void Delete(int Id);
        void Save(ProductModel model);
        ProductModel Get(int Id);
        List<ProductModel> GetList();
    }
}
