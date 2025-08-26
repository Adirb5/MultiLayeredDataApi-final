using MultiLayeredDataApi.DTOs;
using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Storage
{
    public interface ICompositeStorage
    {
        Task SaveAsync(DataItemDto item);
        Task<DataItem?> GetAsync(int id);
        Task UpdateAsync(DataItemDto item);
    }
}
