using Microsoft.EntityFrameworkCore;
using mshop_api.Models;

namespace mshop_api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
