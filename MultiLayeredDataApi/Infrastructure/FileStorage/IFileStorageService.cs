namespace MultiLayeredDataApi.Infrastructure.FileStorage
{
    public interface IFileStorageService
    {
        void SaveToFile(string path, string data);
        string? ReadFromFile(string path);
    }
}
