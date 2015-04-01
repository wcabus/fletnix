using System;
using System.Threading.Tasks;

namespace Fletnix.Domain.Caching
{
    public sealed class Cache
    {
        private ICacheProvider _cacheProvider;

        public Cache(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public T Get<T>(string key) where T : class
        {
            return _cacheProvider.Get<T>(key);
        }

        public T Get<T>(string key, Func<T> retrieveMethod) where T : class
        {
            return _cacheProvider.Get(key, retrieveMethod, TimeSpan.FromMinutes(10));
        }

        public T Get<T>(string key, Func<T> retrieveMethod, TimeSpan expiration) where T : class
        {
            return _cacheProvider.Get(key, retrieveMethod, expiration);
        }

        public Task<T> GetAsync<T>(string key) where T : class
        {
            return _cacheProvider.GetAsync<T>(key);
        }

        public Task<T> GetAsync<T>(string key, Func<Task<T>> retrieveMethod) where T : class
        {
            return _cacheProvider.GetAsync(key, retrieveMethod, TimeSpan.FromMinutes(10));
        }

        public Task<T> GetAsync<T>(string key, Func<Task<T>> retrieveMethod, TimeSpan expiration) where T : class
        {
            return _cacheProvider.GetAsync(key, retrieveMethod, expiration);
        }

        public void Set<T>(string key, T data) where T : class
        {
            _cacheProvider.Set(key, data, TimeSpan.FromMinutes(10));
        }

        public void Set<T>(string key, T data, TimeSpan expires) where T : class
        {
            _cacheProvider.Set(key, data, expires);
        }

        public void Remove(string key)
        {
            _cacheProvider.Remove(key);
        }
    }
}