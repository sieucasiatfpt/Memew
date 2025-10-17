using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memeo.DAO.Entities
{
    public class Product
    {
        public Guid ProductID { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string Status { get; set; } = "Active";
        public string? Images { get; set; }

        public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
