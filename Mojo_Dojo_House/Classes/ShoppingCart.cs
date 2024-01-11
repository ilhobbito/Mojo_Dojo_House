using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Classes
{
    internal class ShoppingCart
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public virtual Product Product { get; set; }
    }
}
