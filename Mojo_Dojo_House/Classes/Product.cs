using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int? SupplierId { get; set; } // Foreign key for Supplier
        public int InventoryBalance { get; set; }
        public bool? Recommended { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; } // Single Supplier
        public virtual ICollection<Order> Orders { get; set; }
    }
}
