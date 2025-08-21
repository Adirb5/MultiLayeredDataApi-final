using Microsoft.Extensions.Caching.Memory;

namespace MultiLayeredDataApi.Infrastructure.Cache
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;
        public CacheService(IMemoryCache cache) => _cache = cache;

        public void Set<T>(string key, T value, TimeSpan ttl) =>
            _cache.Set(key, value, ttl);

        public T? Get<T>(string key) =>
            _cache.TryGetValue(key, out T value) ? value : default;
    }

}
