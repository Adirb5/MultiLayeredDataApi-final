using MultiLayeredDataApi.Infrastructure.Cache;
using MultiLayeredDataApi.Infrastructure.FileStorage;
using MultiLayeredDataApi.Models;
using MultiLayeredDataApi.Repositories;

namespace MultiLayeredDataApi.Storage
{
    public class CompositeStorage : ICompositeStorage
    {
        private readonly ICacheService _cache;
        private readonly IFileStorageService _file;
        private readonly IDataRepository _repo;

        public CompositeStorage(
            ICacheService cache,
            IFileStorageService file,
            IDataRepository repo)
        {
            _cache = cache;
            _file = file;
            _repo = repo;
        }

        public async Task SaveAsync(DataItem item)
        {
            
            _cache.Save(item.Id.ToString(), item.Value);

            _file.SaveToFile($"{item.Id}.txt", item.Value);

            await _repo.AddAsync(item);
        }

        public async Task<DataItem?> GetAsync(int id)
        {
            var fromCache = _cache.Get(id.ToString());
            if (fromCache is not null)
            {
                return new DataItem { Id = id, Value = fromCache };
            }

            var fromFile = _file.ReadFromFile($"{id}.txt");
            if (fromFile is not null)
            {
                _cache.Save(id.ToString(), fromFile); 
                return new DataItem { Id = id, Value = fromFile };
            }

            return await _repo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(DataItem item)
        {
            _cache.Save(item.Id.ToString(), item.Value);

            _file.SaveToFile($"{item.Id}.txt", item.Value);

            await _repo.UpdateAsync(item);
        }
    }
}
