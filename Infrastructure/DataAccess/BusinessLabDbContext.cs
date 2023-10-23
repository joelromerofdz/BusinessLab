using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class BusinessLabDbContext : DbContext
    {
        public BusinessLabDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            var status = modelBuilder.Entity<Status>();
            status.HasKey(s => s.Id);
            status.Property(s => s.Id)
                  .HasDefaultValueSql("NEWID()")
                  .ValueGeneratedOnAdd();

            var product = modelBuilder.Entity<Product>();
            product.HasKey(x => x.Id);
            product.Property(p => p.Id)
                   .HasDefaultValueSql("NEWID()")
                   .ValueGeneratedOnAdd();

            product.HasOne(p => p.Status)
                   .WithMany()
                   .HasForeignKey(p => p.StatusId);
        }
    }
}
