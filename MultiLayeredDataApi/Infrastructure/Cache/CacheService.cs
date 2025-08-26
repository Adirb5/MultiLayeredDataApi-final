namespace MultiLayeredDataApi.Infrastructure.Cache
{
    public class CacheService : ICacheService
    {
        private readonly Dictionary<string, string> _cache = new();

        public void Save(string key, string value) => _cache[key] = value;
        public string? Get(string key) => _cache.TryGetValue(key, out var v) ? v : null;
    }
}
