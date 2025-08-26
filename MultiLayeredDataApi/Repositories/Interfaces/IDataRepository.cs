using MultiLayeredDataApi.DTOs;
using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Repositories
{
    public interface IDataRepository
    {
        Task<DataItem?> GetByIdAsync(int id);
        Task AddAsync(DataItemDto item);
        Task UpdateAsync(DataItemDto item);
    }
}
