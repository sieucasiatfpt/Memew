using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memew.BO.Models
{
        public record ProductDTO(Guid Id, string Name, string? Type, string Status, decimal? MinPrice);
}
