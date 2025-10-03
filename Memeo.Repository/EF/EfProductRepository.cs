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
        => db.Products.Include(p => p.Sizes).ToListAsync(ct);

        public Task<Product?> GetAsync(Guid id, CancellationToken ct = default)
            => db.Products.Include(p => p.Sizes).FirstOrDefaultAsync(p => p.Id == id, ct);

        public async Task<Product> AddAsync(Product e, CancellationToken ct = default)
        { db.Products.Add(e); await db.SaveChangesAsync(ct); return e; }

        public async Task UpdateAsync(Product e, CancellationToken ct = default)
        { db.Entry(e).State = EntityState.Modified; await db.SaveChangesAsync(ct); }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        { var e = await db.Products.FindAsync([id], ct); if (e != null) { db.Remove(e); await db.SaveChangesAsync(ct); } }
    }
}
