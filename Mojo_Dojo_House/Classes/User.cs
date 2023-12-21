using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Classes
{
    internal class User
    {
        public int Id { get; set; }
        public int? CardId { get; set; }
        public int? PersonId { get; set; }
        public int? AdressId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
         public ICollection<Person> Persons { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Adress> Adresses { get; set; }
    }
}
