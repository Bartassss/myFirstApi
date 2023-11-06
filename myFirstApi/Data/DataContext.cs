using Microsoft.EntityFrameworkCore;

namespace myFirstApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet <Product> Products { get; set; }
        public object Product { get; internal set; }
    }
}
