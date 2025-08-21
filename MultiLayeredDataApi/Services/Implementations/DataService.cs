using MultiLayeredDataApi.DTOs;
using MultiLayeredDataApi.Infrastructure.Cache;
using MultiLayeredDataApi.Infrastructure.FileStorage;
using MultiLayeredDataApi.Models;
using MultiLayeredDataApi.Repositories.Interfaces;
using MultiLayeredDataApi.Services.Interfaces;

namespace MultiLayeredDataApi.Services.Implementations
{
    public class DataService : IDataService
    {
        private readonly CacheService _cache;
        private readonly FileStorageService _fileStorage;
        private readonly IDataRepository _repo;

        public DataService(CacheService cache, FileStorageService fileStorage, IDataRepository repo)
        {
            _cache = cache;
            _fileStorage = fileStorage;
            _repo = repo;
        }

        public async Task<DataItem?> GetData(int id)
        {
            // 1. Cache
            var cached = _cache.Get<DataItem>($"data_{id}");
            if (cached != null) return cached;

            // 2. File
            var fromFile = _fileStorage.Load<DataItem>(id);
            if (fromFile != null)
            {
                _cache.Set($"data_{id}", fromFile, TimeSpan.FromMinutes(10));
                return fromFile;
            }

            // 3. Database
            var fromDb = await _repo.GetByIdAsync(id);
            if (fromDb != null)
            {
                _cache.Set($"data_{id}", fromDb, TimeSpan.FromMinutes(10));
                _fileStorage.Save(id, fromDb, TimeSpan.FromMinutes(30));
                return fromDb;
            }

            return null; // לא נמצא
        }

        public async Task AddData(DataItemDto dto)
        {
            var entity = new DataItem
            {
                Id = dto.Id,
                Value = dto.Value,
                CreatedAt = DateTime.UtcNow
            };
            await _repo.AddAsync(entity);
        }

        public async Task UpdateData(int id, DataItemDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return;

            entity.Value = dto.Value;
            await _repo.UpdateAsync(entity);
        }
    }

}
