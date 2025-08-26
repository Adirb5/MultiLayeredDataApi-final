using MultiLayeredDataApi.Data;
using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Repositories.Implementations
{
    public class DataRepository : IDataRepository
    {
        private readonly AppDbContext _context;
        public DataRepository(AppDbContext context) => _context = context;

        public async Task<DataItem?> GetByIdAsync(int id) =>
            await _context.DataItems.FindAsync(id);

        public async Task AddAsync(DataItem item)
        {
            _context.DataItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DataItem item)
        {
            _context.DataItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }

}
