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
        Task<Product?> GetAsync(Guid productId, CancellationToken ct = default);
        Task<List<Product>> GetByNameAsync(string name, CancellationToken ct = default);
        Task<Product> AddAsync(Product e, CancellationToken ct = default);
        Task UpdateAsync(Product e, CancellationToken ct = default);
        Task DeleteAsync(Guid productId, CancellationToken ct = default);
    }
}
