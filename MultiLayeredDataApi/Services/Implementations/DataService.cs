using MultiLayeredDataApi.DTOs;
using MultiLayeredDataApi.Factories;
using MultiLayeredDataApi.Models;
using MultiLayeredDataApi.Services.Interfaces;
using MultiLayeredDataApi.Storage;
using System.ComponentModel;

namespace MultiLayeredDataApi.Services
{
    public class DataService : IDataService
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

        public async Task AddDataAsync(DataItemDto item)
        {
            await _storage.SaveAsync(item);
        }

        public async Task UpdateDataAsync(DataItemDto item)
        {
            await _storage.UpdateAsync(item);
        }
    }
}
