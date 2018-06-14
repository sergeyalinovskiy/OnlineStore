namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion
    public interface ISearchService
    {
        IEnumerable<Product> ProductByCategory(int category);
    }
}