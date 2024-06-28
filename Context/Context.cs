using Microsoft.EntityFrameworkCore;
using Retail_Store.Models;
namespace Retail_Store.Context
{
    public class RetailStoreContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }

        public RetailStoreContext(DbContextOptions<RetailStoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
