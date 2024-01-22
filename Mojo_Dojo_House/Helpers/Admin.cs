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
            bool admin = true;
            int LocationInfo = 0;
            while (admin)
            {
                Console.Clear();
                Draw.AdminPage();
                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        Draw.AdminProducts();
                        LocationInfo = 1;
                        break;
                    case '2':
                        Draw.AdminCategories();
                        LocationInfo = 2;
                        //vissa hur många okategoriserad produkter som finns (med ett tal)
                        break;
                    case '3':
                        Draw.AdminUsers();
                        LocationInfo = 3;
                        break;
                    case '4':
                        Draw.AdminOrderInfo();
                        LocationInfo = 4;
                        break;
                    case 'L':
                        LoginSettnings.Logout();
                        admin = false;
                        Draw.DrawLogIn();
                        break;
                    case 'd':
                        //delete
                        break;
                    case 's':
                        //change
                        break;
                    case 'a':
                        Helper.AdminAddSelect(LocationInfo);
                        break;
                }
            }
        }
    }
}
