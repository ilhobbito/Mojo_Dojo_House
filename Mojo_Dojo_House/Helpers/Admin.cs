using Microsoft.Identity.Client;
using Mojo_Dojo_House.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Helpers
{
    internal class Admin
    {
        public static void AdminSite()
        {
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case '1':
                    Draw.ProductPage();
                    break;
                case '2':
                    Draw.CategoryPage();
                    break;
                case '3':
                    Draw.UserPage();
                    break;
                case 'L':
                    LoginSettnings.Logout();
                    Draw.DrawLogIn();
                    break;
            }
        }
        public static void ProductSite()
        {
            //ta bort, göra nya eller ändra
            //productnamn, infotext, pris, productkategori, leverantör eller lagersaldo
            var products = Helper.GetProductsAdmin();
            var productWindow = new Classes.Window($"", 20, 5, products);
            productWindow.Draw();
            Console.ReadLine();
        }
        public static void CategorySite()
        {
            //kunna lägga till/ta bort kategorier eller ändra namn eller description
        }
        public static void UserSite()
        {
            // kinnda lägga till, ta bort eller ändra kunder upggifter
            //kunna se beställning historik
        }
    }
}
