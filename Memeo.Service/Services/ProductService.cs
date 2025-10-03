using Memeo.DAO.Entities;
using Memeo.Repository.Abstractions;
using Memew.BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memeo.Service.Services
{
    public class ProductService(IProductRepository repo) : IProductService
    {
        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var list = await repo.GetAllAsync();
            return list.Select(p => new ProductDTO(
                p.Id, p.Name, p.Type, p.Status,
                p.Sizes.Any() ? p.Sizes.Min(s => s.UnitPrice) : null
            )).ToList();
        }

        public async Task<ProductDTO?> GetAsync(Guid id)
        {
            var p = await repo.GetAsync(id);
            return p is null ? null
                : new ProductDTO(p.Id, p.Name, p.Type, p.Status,
                    p.Sizes.Any() ? p.Sizes.Min(s => s.UnitPrice) : null);
        }

        public async Task<ProductDTO> CreateAsync(string name, string? type, string status)
        {
            var e = await repo.AddAsync(new Product { Name = name, Type = type, Status = status });
            return new ProductDTO(e.Id, e.Name, e.Type, e.Status, null);
        }

        public async Task UpdateNameAsync(Guid id, string name)
        {
            var p = await repo.GetAsync(id) ?? throw new KeyNotFoundException("Product not found");
            p.Name = name; await repo.UpdateAsync(p);
        }

        public Task DeleteAsync(Guid id) => repo.DeleteAsync(id);
    }
}
