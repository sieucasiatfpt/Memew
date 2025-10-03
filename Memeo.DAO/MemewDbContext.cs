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
            // 1-n: Product - ProductSize
            b.Entity<ProductSize>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.Sizes)
                .HasForeignKey(ps => ps.ProductId);

            // Kiểu tiền tệ
            b.Entity<ProductSize>().Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");

            // Cột text dài cho Images
            b.Entity<Product>().Property(x => x.Images).HasMaxLength(4000);

            // (Tuỳ chọn) Seed data mẫu
            // b.Entity<Product>().HasData(new Product { Id = ..., Name = "Cat Meme Tee" });
        }
    }
}
