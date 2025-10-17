using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memeo.DAO.Entities
{
    public class ProductSize
    {
        public Guid ProductSizesID { get; set; } = Guid.NewGuid();
        public Guid ProductID { get; set; }
        public string ProductSizeName { get; set; } = default!;
        public string? Colors { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; } = default!;
    }
}
