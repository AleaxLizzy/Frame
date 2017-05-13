using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Cache
{
    /// <summary>
    ///     Extensions
    /// </summary>
    public static class CacheExtensions
    {
        public static T Get<T>(this ICacheService cacheService, string key, Func<T> acquire)
        {
            return Get(cacheService, key, new TimeSpan(60), acquire);
        }

        public static T Get<T>(this ICacheService cacheService, string key, TimeSpan cacheTiem, Func<T> acquire)
        {
            if (cacheService.Contains(key))
            {
                return cacheService.Get<T>(key);
            }
            var result = acquire();
            cacheService.Set(key, result, cacheTiem);
            return result;
        }
    }
}
