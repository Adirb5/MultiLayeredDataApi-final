using MultiLayeredDataApi.Data;
using MultiLayeredDataApi.DTOs;
using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Repositories.Implementations
{
    public class DataRepository : IDataRepository
    {
        private readonly AppDbContext _context;
        public DataRepository(AppDbContext context) => _context = context;

        public async Task<DataItem?> GetByIdAsync(int id) =>
            await _context.DataItems.FindAsync(id);

        public async Task AddAsync(DataItemDto item)
        {
            DataItem addNew = new DataItem() { Id= item.Id, Value = item.Value, CreatedAt = DateTime.Now};
            _context.DataItems.Add(addNew);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DataItemDto item)
        {
            DataItem update = new DataItem() { Id = item.Id, Value = item.Value };

            _context.DataItems.Update(update);
            await _context.SaveChangesAsync();
        }
    }

}
