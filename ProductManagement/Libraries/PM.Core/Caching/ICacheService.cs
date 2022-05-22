using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Core.Caching
{
    public interface ICacheService
    {
        T Get<T>(string key);
        T GetOrCreate<T>(string key, Func<T> func);
        Task<T> GetOrCreate<T>(string key, Func<Task<T>> func);
        void Add(string key, object data);
        void Remove(string key);
        void Clear();
        bool Any(string key);
        List<string> FindKeysByPrefix(string prefix);
    }
}
