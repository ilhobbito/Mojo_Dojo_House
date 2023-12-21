using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Classes
{
    internal class Toy_Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Mojo_Dojo;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Classes.Adress> Adresses { get; set; }
        public DbSet<Classes.Card> Cards { get; set; }
        public DbSet<Classes.Category> Categories { get; set; }
        public DbSet<Classes.Order> Orders { get; set; }
        public DbSet<Classes.Person> Persons { get; set; }
        public DbSet<Classes.Product> Products { get; set; }
        public DbSet<Classes.Supplier> Suppliers { get; set; }
        public DbSet<Classes.User> Users { get; set; }
    }
}
