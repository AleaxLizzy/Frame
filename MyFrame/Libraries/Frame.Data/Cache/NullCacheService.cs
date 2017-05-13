using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Cache
{
    public class NullCacheService : ICacheService
    {
        public T Get<T>(string key)
        {
            return default(T);
        }

        public void Set(string key, object value, TimeSpan cacheTiem)
        {

        }

        public bool Contains(string key)
        {
            return false;
        }

        public void Remove(string key)
        {

        }

        public void Clear()
        {

        }
    }

}
