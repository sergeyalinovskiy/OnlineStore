using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Common.Cache
{
    public interface IStoreCache
    {
        bool Create(string key, IReadOnlyCollection<Product> item, int minutes);
        void Delete(string key);
        IReadOnlyCollection<Product> GetCache(string key);
        void Update(string key, IReadOnlyCollection<Product> item, int minutes);
    }
}
