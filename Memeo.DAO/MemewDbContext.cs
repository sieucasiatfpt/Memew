using Memeo.DAO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memeo.DAO
{
    public class MemewDbContext : DbContext
    {
        public MemewDbContext(DbContextOptions<MemewDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            // Configure Product entity
            b.Entity<Product>()
                .HasKey(p => p.ProductID);

            b.Entity<Product>()
                .Property(p => p.Images)
                .HasMaxLength(4000);

            // Configure ProductSize entity
            b.Entity<ProductSize>()
                .HasKey(ps => ps.ProductSizesID);

            b.Entity<ProductSize>()
                .Property(ps => ps.UnitPrice)
                .HasColumnType("decimal(18,2)");

            // 1-n: Product - ProductSize
            b.Entity<ProductSize>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(ps => ps.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
