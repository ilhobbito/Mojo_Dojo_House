using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Classes
{
    internal class Order
    {
        public int Id { get; set; }
        public int?  UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public DateTime? CurrentDate { get; set; } = DateTime.Now;
    }
}
