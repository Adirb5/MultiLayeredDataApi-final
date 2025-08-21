using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Repositories.Interfaces
{
    public interface IDataRepository
    {
        Task<DataItem?> GetByIdAsync(int id);
        Task AddAsync(DataItem item);
        Task UpdateAsync(DataItem item);
    }

}
