using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? CurrentDate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
