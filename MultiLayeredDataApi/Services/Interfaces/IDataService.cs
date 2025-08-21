using MultiLayeredDataApi.DTOs;
using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Services.Interfaces
{
    public interface IDataService
    {
        Task<DataItem?> GetData(int id);
        Task AddData(DataItemDto dto);
        Task UpdateData(int id, DataItemDto dto);
    }

}
