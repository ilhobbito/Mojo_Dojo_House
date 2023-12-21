using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Classes
{
    internal class Supplier
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? AdressId { get; set; }
        public Adress? Adress { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}
