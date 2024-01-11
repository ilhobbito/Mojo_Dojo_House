using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Helpers
{
    internal class Login
    {
        public static void LoginAttempt()
        {
            if (LoginSettnings.IsUserLoggedIn == false)
            {
                Console.WriteLine("Please enter username");
                string username = Console.ReadLine();

                Console.WriteLine("Please enter password");
                string password = Console.ReadLine();
                if (username == "admin" && password == "admin")
                {
                    LoginSettnings.Login(username);
                    Draw.AdminPage();
                }
                else
                {
                    LoginSettnings.Login(username);
                }
            }

            else if (LoginSettnings.IsUserLoggedIn == true)
            {
                LoginSettnings.Logout();
            }

        }
    }
}
