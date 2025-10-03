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
        Task<ProductDTO?> GetAsync(Guid id);
        Task<ProductDTO> CreateAsync(string name, string? type, string status);
        Task UpdateNameAsync(Guid id, string name);
        Task DeleteAsync(Guid id);
    }
}
