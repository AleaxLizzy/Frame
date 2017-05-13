using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Cache
{
    public class MemoryCacheService : ICacheService
    {

        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }
        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public virtual void Set(string key, object value, TimeSpan cacheTiem)
        {
            if (value == null)
                return;
            Cache.Set(key, value, new CacheItemPolicy { SlidingExpiration = cacheTiem });
        }

        public bool Contains(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void Clear()
        {
            var cache = MemoryCache.Default;
            foreach (var item in cache)
            {
                this.Remove(item.Key);
            }
        }
    }
}
