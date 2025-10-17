using Memeo.DAO;
using Memeo.DAO.Entities;
using Memeo.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memeo.Repository.EF
{
    public class EfProductRepository(MemewDbContext db) : IProductRepository
    {
        public Task<List<Product>> GetAllAsync(CancellationToken ct = default)
            => db.Products.Include(p => p.ProductSizes).ToListAsync(ct);

        public Task<Product?> GetAsync(Guid productId, CancellationToken ct = default)
            => db.Products.Include(p => p.ProductSizes).FirstOrDefaultAsync(p => p.ProductID == productId, ct);

        public Task<List<Product>> GetByNameAsync(string name, CancellationToken ct = default)
            => db.Products
                  .Include(p => p.ProductSizes)
                  .Where(p => Microsoft.EntityFrameworkCore.EF.Functions.Like(p.Name, $"%{name}%"))
                  .ToListAsync(ct);

        public async Task<Product> AddAsync(Product e, CancellationToken ct = default)
        { 
            db.Products.Add(e); 
            await db.SaveChangesAsync(ct); 
            return e; 
        }

        public async Task UpdateAsync(Product e, CancellationToken ct = default)
        { 
            db.Entry(e).State = EntityState.Modified; 
            await db.SaveChangesAsync(ct); 
        }

        public async Task DeleteAsync(Guid productId, CancellationToken ct = default)
        { 
            var e = await db.Products.FindAsync([productId], ct); 
            if (e != null) 
            { 
                db.Remove(e); 
                await db.SaveChangesAsync(ct); 
            } 
        }
    }
}
