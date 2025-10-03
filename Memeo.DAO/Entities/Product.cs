using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memeo.DAO.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Type { get; set; }            // Shirt, Sticker, Keyring...
        public string Status { get; set; } = "Active";
        public string? Images { get; set; }          // JSON/CSV link ảnh
        public ICollection<ProductSize> Sizes { get; set; } = new List<ProductSize>();
    }
}
