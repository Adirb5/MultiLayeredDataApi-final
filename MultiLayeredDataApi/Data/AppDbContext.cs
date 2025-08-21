using Microsoft.EntityFrameworkCore;
using MultiLayeredDataApi.Models;

namespace MultiLayeredDataApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DataItem> DataItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
