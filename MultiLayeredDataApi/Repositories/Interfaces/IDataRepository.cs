using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Repositories
{
    public interface IDataRepository
    {
        Task<DataItem?> GetByIdAsync(int id);
        Task AddAsync(DataItem item);
        Task UpdateAsync(DataItem item);
    }
}
