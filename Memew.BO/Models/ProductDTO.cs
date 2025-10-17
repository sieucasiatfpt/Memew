using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memew.BO.Models
{
    public record ProductDTO(
        Guid ProductID,
        string Name,
        string? Description,
        string? Type,
        string Status,
        string? Images,
        decimal? MinPrice
    );
}
