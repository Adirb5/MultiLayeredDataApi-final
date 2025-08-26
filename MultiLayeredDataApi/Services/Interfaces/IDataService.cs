using MultiLayeredDataApi.DTOs;
using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Services.Interfaces
{
    public interface IDataService
    {
        Task<DataItem?> GetDataAsync(int id);
        Task AddDataAsync(DataItemDto dto);
        Task UpdateDataAsync(DataItemDto dto);
    }

}
