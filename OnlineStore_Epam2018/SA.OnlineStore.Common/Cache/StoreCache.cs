using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Common.Cache
{
    public class StoreCache : IStoreCache
    {
        private MemoryCache _cache;

        public StoreCache()
        {
            _cache = MemoryCache.Default;
        }

        public bool Create(string key, IReadOnlyCollection<Product> item, int minutes)
        {
            if (item == null)
            {
                return false;
            }
            var result = _cache.Add(key, item, DateTime.Now.AddMinutes(minutes));
            return result;
        }

        public void Delete(string key)
        {
            if (_cache.Contains(key))
            {
                _cache.Remove(key);
            }
        }

        public IReadOnlyCollection<Product> GetCache(string key)
        {
            var cache = _cache.Get(key);
            var item = cache as IReadOnlyCollection<Product>;
            return item;
        }

        public void Update(string key, IReadOnlyCollection<Product> item,int minutes)
        {
            if (item == null)
            {
                return;
            }
            _cache.Set(key, item, DateTime.Now.AddMinutes(minutes));
        }
    }
}