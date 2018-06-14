namespace SA.OnlineStore.DataAccess.Repositorys
{
    #region Usings
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.DataAccess.Implements;
        using System.Collections.Generic;
    #endregion
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> SearchProducts(string name, int category, int minValue, int maxValue);
    }
}