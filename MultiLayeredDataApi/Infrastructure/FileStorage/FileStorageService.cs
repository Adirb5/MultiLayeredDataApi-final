namespace MultiLayeredDataApi.Infrastructure.FileStorage
{
    public class FileStorageService : IFileStorageService
    {
        public void SaveToFile(string path, string data) => File.WriteAllText(path, data);
        public string? ReadFromFile(string path) => File.Exists(path) ? File.ReadAllText(path) : null;
    }
}
