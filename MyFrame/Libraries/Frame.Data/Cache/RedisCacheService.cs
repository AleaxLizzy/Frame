using Frame.Data.Config;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frame.Util;
using Frame.Util.Extension;
namespace Frame.Data.Cache
{
    public class RedisCacheService : ICacheService
    {
        private readonly string _redisConnectionString;
        private volatile ConnectionMultiplexer _redisConnection;
        private readonly object _redisConnectionLock = new object();


        public RedisCacheService(ApplicationConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.RedisCacheConfig.Connectionstring))
            {
                throw new ArgumentException("redis  config is empty", "config");
            }
            _redisConnectionString = config.RedisCacheConfig.Connectionstring;
            _redisConnection = GetRedisConnection();
        }

        private ConnectionMultiplexer GetRedisConnection()
        {
            if (_redisConnection != null && _redisConnection.IsConnected)
            {
                return _redisConnection;
            }
            lock (_redisConnectionLock)
            {
                if (_redisConnection != null)
                {
                    _redisConnection.Dispose();
                }
                _redisConnection = ConnectionMultiplexer.Connect(_redisConnectionString);
            }
            return _redisConnection;
        }
        public T Get<T>(string key)
        {
            var value = _redisConnection.GetDatabase().StringGet(key);
            return Json.Deserialize<T>(value);
        }

        public void Set(string key, object value, TimeSpan cacheTiem)
        {
            if (value != null)
            {
                _redisConnection.GetDatabase().StringSet(key, value.Serialize(), cacheTiem);
            }
        }

        public bool Contains(string key)
        {
            return _redisConnection.GetDatabase().KeyExists(key);
        }

        public void Remove(string key)
        {
            _redisConnection.GetDatabase().KeyDelete(key);
        }

        public void Clear()
        {
            foreach (var endPoint in this.GetRedisConnection().GetEndPoints())
            {
                var server = this.GetRedisConnection().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    Remove(key);
                }
            }
        }
    }

}
