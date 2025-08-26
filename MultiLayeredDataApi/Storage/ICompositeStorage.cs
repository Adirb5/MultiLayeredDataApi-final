using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Storage
{
    public interface ICompositeStorage
    {
        Task SaveAsync(DataItem item);
        Task<DataItem?> GetAsync(int id);
        Task UpdateAsync(DataItem item);
    }
}
