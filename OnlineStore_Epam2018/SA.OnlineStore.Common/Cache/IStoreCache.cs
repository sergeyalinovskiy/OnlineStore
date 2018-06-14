namespace SA.OnlineStore.Common.Cache
{
    #region Usings
        using SA.OnlineStore.Common.Entity;
        using System.Collections.Generic;
    #endregion
    public interface IStoreCache
    {
        bool Create(string key, IReadOnlyCollection<Product> item, int minutes);
        void Delete(string key);
        IReadOnlyCollection<Product> GetCache(string key);
        void Update(string key, IReadOnlyCollection<Product> item, int minutes);
    }
}