using System;
using System.Threading.Tasks;

namespace Fletnix.Domain.Caching
{
    public interface ICacheProvider
    {
        T Get<T>(string key) where T : class;

        T Get<T>(string key, Func<T> retrieveMethod, TimeSpan expiration) where T : class;

        Task<T> GetAsync<T>(string key) where T : class;

        Task<T> GetAsync<T>(string key, Func<Task<T>> retrieveMethod, TimeSpan expiration) where T : class;

        void Set<T>(string key, T data, TimeSpan expires) where T : class;

        void Remove(string key); 
    }
}