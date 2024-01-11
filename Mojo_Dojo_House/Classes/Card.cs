using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Classes
{
    public class Card
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
