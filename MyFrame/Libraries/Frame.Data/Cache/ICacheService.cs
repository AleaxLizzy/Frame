using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data.Cache
{
    public interface ICacheService
    {
        T Get<T>(string key);

        void Set(string key, object value, TimeSpan cacheTiem);

        bool Contains(string key);

        void Remove(string key);

        void Clear();
    }
}
