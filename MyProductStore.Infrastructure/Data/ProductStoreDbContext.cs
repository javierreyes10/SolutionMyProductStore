using Microsoft.EntityFrameworkCore;
using MyProductStore.Core.Entities;
using System.Reflection;

namespace MyProductStore.Infrastructure.Data
{
    public class ProductStoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public ProductStoreDbContext(DbContextOptions<ProductStoreDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
