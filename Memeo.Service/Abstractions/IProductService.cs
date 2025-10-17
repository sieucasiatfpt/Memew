using Memew.BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memeo.Repository.Abstractions
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetAsync(Guid productId);
        Task<List<ProductDTO>> GetByNameAsync(string name);
        Task<ProductDTO> CreateAsync(string name, string? description, string? type, string status, string? images);
        Task UpdateNameAsync(Guid productId, string name);
        Task DeleteAsync(Guid productId);
    }
}
