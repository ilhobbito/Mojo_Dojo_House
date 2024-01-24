using Azure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Helpers
{
    public class Login
    {
        public static bool logIn = false;
        public static string username = "";
        public static void LoginAttempt()
        {
            
            if (logIn == false)
            {
                Console.WriteLine("Skriv in ditt användarnamn");
                username = Console.ReadLine();
                logIn = true;
                if (username == "admin")
                {
                    Admin.AdminSite();
                }
                else
                {
                }
            }
            else
            {
                logIn = false;
                username = "";
            }

        }
        public static void LoginBox()
        {

            if (logIn == true)
            {
                List<string> LogIn = new List<string> { username };
                var windowLogIn = new Classes.Window("", 2, 1, LogIn);
                windowLogIn.Left = 70;
                windowLogIn.Draw();
            }
            else
            {
                List<string> LogIn = new List<string> { "L: Logga in" };
                var windowLogIn = new Classes.Window("", 2, 1, LogIn);
                windowLogIn.Left = 70;
                windowLogIn.Draw();
            }
        }
    }
}
