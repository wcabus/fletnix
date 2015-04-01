using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using Fletnix.Domain.Caching;

namespace Fletnix.Web.Caching
{
    public sealed class CacheProvider : ICacheProvider
    {
        public T Get<T>(string key) where T : class
        {
            var data = HttpRuntime.Cache.Get(key) as T;
            return data;
        }

        public T Get<T>(string key, Func<T> retrieveMethod, TimeSpan expiration) where T : class
        {
            var data = HttpRuntime.Cache.Get(key) as T;
            if (data == null)
            {
                data = retrieveMethod();
                HttpRuntime.Cache.Add(key, data, null, System.Web.Caching.Cache.NoAbsoluteExpiration, expiration, CacheItemPriority.Normal, null);
            }

            return data;
        }

        public Task<T> GetAsync<T>(string key) where T : class
        {
            var data = HttpRuntime.Cache.Get(key) as T;
            return Task.FromResult(data);
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> retrieveMethod, TimeSpan expiration) where T : class
        {
            var data = HttpRuntime.Cache.Get(key) as T;
            if (data == null)
            {
                data = await retrieveMethod();
                HttpRuntime.Cache.Add(key, data, null, System.Web.Caching.Cache.NoAbsoluteExpiration, expiration, CacheItemPriority.Normal, null);
            }

            return data;
        }

        public void Set<T>(string key, T data, TimeSpan expires) where T : class
        {
            HttpRuntime.Cache.Remove(key);
            HttpRuntime.Cache.Add(key, data, null, System.Web.Caching.Cache.NoAbsoluteExpiration, expires, CacheItemPriority.Normal, null);
        }

        public void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
    }
}