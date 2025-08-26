namespace MultiLayeredDataApi.Infrastructure.Cache
{
    public interface ICacheService
    {
        void Save(string key, string value);
        string? Get(string key);
    }
}
