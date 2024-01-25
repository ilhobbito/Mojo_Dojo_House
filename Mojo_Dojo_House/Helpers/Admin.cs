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
            Console.Clear();
            Draw.AdminPage();
            while (admin)
            {
                var key = Console.ReadKey();
                Console.Clear();
                switch (key.KeyChar)
                {
                    case '1':
                        Draw.AdminProducts();
                        LocationInfo = 1;
                        break;
                    case '2':
                        Draw.AdminCategories();
                        LocationInfo = 2;
                        break;
                    case '3':
                        Draw.AdminUsers();
                        LocationInfo = 3;
                        break;
                    case '4':
                        Draw.AdminOrderInfo();
                        LocationInfo = 4;
                        break;
                    case '5':
                        Draw.DrawQuieries();
                        break;
                    case 'l':
                        Login.LoginAttempt();
                        admin = false;
                        break;
                    case 'd':
                        Draw.AdminPage();
                        Helper.AdminDeleteSelect(LocationInfo);
                        break;
                    case 's':
                        Draw.AdminPage();
                        Helper.AdminChangeSelect(LocationInfo);
                        break;
                    case 'a':
                        Draw.AdminPage();
                        Helper.AdminAddSelect(LocationInfo);
                        break;
                    default:
                        Draw.AdminPage();
                        break;
                }
            }
        }
    }
}
