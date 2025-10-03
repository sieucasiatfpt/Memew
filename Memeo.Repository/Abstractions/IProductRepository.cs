using Memeo.DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memeo.Repository.Abstractions
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(CancellationToken ct = default);
        Task<Product?> GetAsync(Guid id, CancellationToken ct = default);
        Task<Product> AddAsync(Product entity, CancellationToken ct = default);
        Task UpdateAsync(Product entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
