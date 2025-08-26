using MultiLayeredDataApi.Factories;
using MultiLayeredDataApi.Models;
using MultiLayeredDataApi.Storage;

namespace MultiLayeredDataApi.Services
{
    public class DataService
    {
        private readonly ICompositeStorage _storage;

        public DataService(IStorageFactory factory)
        {
            _storage = factory.CreateCompositeStorage();
        }

        public async Task<DataItem?> GetDataAsync(int id)
        {
            return await _storage.GetAsync(id);
        }

        public async Task AddDataAsync(DataItem item)
        {
            await _storage.SaveAsync(item);
        }

        public async Task UpdateDataAsync(DataItem item)
        {
            await _storage.UpdateAsync(item);
        }
    }
}
