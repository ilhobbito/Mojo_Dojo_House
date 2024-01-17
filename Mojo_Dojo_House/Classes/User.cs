using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Classes
{
    public class User
    {
        public int Id { get; set; }
        public int? CardId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
        public virtual Card Card { get; set; }
        public virtual Person Person { get; set; }
    }
}
