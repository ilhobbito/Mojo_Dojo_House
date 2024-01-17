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
                    Admin.AdminSite();
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
    public static class LoginSettnings
    {
        public static bool IsUserLoggedIn { get; private set; } = false;
        public static string Username { get; private set; }

        public static void Login(string name)
        {
            Username = name;
            IsUserLoggedIn = true;
        }

        public static void Logout()
        {
            Username = null;
            IsUserLoggedIn = false;
        }

        public static void LoginBox()
        {
            bool isLoggedIn = LoginSettnings.IsUserLoggedIn;

            if (isLoggedIn == true)
            {
                //fixa så när man loggar in så står det att man är inloggad
                List<string> LogIn = new List<string> { LoginSettnings.Username };
                var windowLogIn = new Classes.Window("", 2, 4, LogIn);
                windowLogIn.Left = 70;
                windowLogIn.Draw();
            }
            else
            {
                List<string> LogIn = new List<string> { "L: Login" };
                var windowLogIn = new Classes.Window("", 2, 4, LogIn);
                windowLogIn.Left = 70;
                windowLogIn.Draw();
            }
        }
    }
}
