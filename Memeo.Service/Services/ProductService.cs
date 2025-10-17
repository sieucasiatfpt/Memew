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
                p.ProductID, 
                p.Name, 
                p.Description,
                p.Type, 
                p.Status,
                p.Images,
                p.ProductSizes.Any() ? p.ProductSizes.Min(s => s.UnitPrice) : null
            )).ToList();
        }

        public async Task<List<ProductDTO>> GetByNameAsync(string name)
        {
            var list = await repo.GetByNameAsync(name);
            return list.Select(p => new ProductDTO(
                p.ProductID,
                p.Name,
                p.Description,
                p.Type,
                p.Status,
                p.Images,
                p.ProductSizes.Any() ? p.ProductSizes.Min(s => s.UnitPrice) : null
            )).ToList();
        }

        public async Task<ProductDTO?> GetAsync(Guid productId)
        {
            var p = await repo.GetAsync(productId);
            return p is null ? null
                : new ProductDTO(
                    p.ProductID, 
                    p.Name, 
                    p.Description,
                    p.Type, 
                    p.Status,
                    p.Images,
                    p.ProductSizes.Any() ? p.ProductSizes.Min(s => s.UnitPrice) : null);
        }

        public async Task<ProductDTO> CreateAsync(string name, string? description, string? type, string status, string? images)
        {
            var product = new Product { Name = name, Description = description, Type = type, Status = status, Images = images };
            var e = await repo.AddAsync(product);
            return new ProductDTO(
                e.ProductID,
                e.Name,
                e.Description,
                e.Type,
                e.Status,
                e.Images,
                e.ProductSizes.Any() ? e.ProductSizes.Min(s => s.UnitPrice) : null);
        }

        public async Task UpdateNameAsync(Guid productId, string name)
        {
            var p = await repo.GetAsync(productId) ?? throw new KeyNotFoundException("Product not found");
            p.Name = name; 
            await repo.UpdateAsync(p);
        }

        public Task DeleteAsync(Guid productId) => repo.DeleteAsync(productId);
    }
}
