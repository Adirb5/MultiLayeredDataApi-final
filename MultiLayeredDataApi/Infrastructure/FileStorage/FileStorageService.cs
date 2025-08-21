using System.Text.Json;

namespace MultiLayeredDataApi.Infrastructure.FileStorage
{
    public class FileStorageService
    {
        private readonly string _basePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage");

        public FileStorageService()
        {
            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);
        }

        public void Save<T>(int id, T data, TimeSpan ttl)
        {
            var filePath = Path.Combine(_basePath, $"{id}_{DateTime.UtcNow.Add(ttl):yyyyMMddHHmmss}.json");
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }

        public T? Load<T>(int id)
        {
            var files = Directory.GetFiles(_basePath, $"{id}_*.json");
            if (!files.Any()) return default;

            var file = files.OrderByDescending(f => f).First();
            var expireTime = DateTime.ParseExact(Path.GetFileNameWithoutExtension(file).Split('_')[1], "yyyyMMddHHmmss", null);

            if (expireTime < DateTime.UtcNow) return default;

            var json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<T>(json);
        }
    }

}
