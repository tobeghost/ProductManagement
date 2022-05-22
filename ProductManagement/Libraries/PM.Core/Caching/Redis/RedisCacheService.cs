using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Core.Caching.Redis
{
    public class RedisCacheService : ICacheService
    {
        private RedisServer _redisServer;

        public RedisCacheService(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }

        public void Add(string key, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);

            _redisServer.Database.StringSet(key, jsonData);
        }

        public bool Any(string key)
        {
            return _redisServer.Database.KeyExists(key);
        }

        public T Get<T>(string key)
        {
            if (Any(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }

        public T GetOrCreate<T>(string key, Func<T> func)
        {
            if (Any(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            else
            {
                var data = func();
                Add(key, data);
                return data;
            }
        }

        public async Task<T> GetOrCreate<T>(string key, Func<Task<T>> func)
        {
            if (Any(key))
            {
                string jsonData = _redisServer.Database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            else
            {
                var data = await func();
                Add(key, data);
                return data;
            }
        }

        public void Remove(string key)
        {
            _redisServer.Database.KeyDelete(key);
        }

        public void Clear()
        {
            _redisServer.FlushDatabase();
        }

        public List<string> FindKeysByPrefix(string prefix)
        {
            var allkeys = _redisServer.Server.Keys(0);
            return allkeys.Where(i => i.ToString().StartsWith(prefix)).Select(i => i.ToString()).ToList();
        }
    }
}
