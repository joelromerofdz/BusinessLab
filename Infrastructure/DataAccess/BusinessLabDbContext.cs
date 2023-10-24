using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class BusinessLabDbContext : DbContext
    {
        public BusinessLabDbContext() { }

        public BusinessLabDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var product = modelBuilder.Entity<Product>();
            product.HasKey(x => x.Id);
            product.Property(p => p.Id)
                   .HasDefaultValueSql("NEWID()")
                   .ValueGeneratedOnAdd();
        }
    }
}
