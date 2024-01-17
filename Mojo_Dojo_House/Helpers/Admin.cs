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
            while (admin)
            {
                Console.Clear();
                Draw.AdminPage();
                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        
                        Draw.ProductPage();
                        ProductSite();
                        break;
                    case '2':
                        
                        Draw.CategoryPage();
                        CategorySite();
                        break;
                    case '3':
                        
                        Draw.UserPage();
                        UserSite();
                        break;
                    case 'L':
                        LoginSettnings.Logout();
                        admin = false;
                        Draw.DrawLogIn();
                        break;
                }
            }
        }
        public static void ProductSite()
        {
            //ta bort, göra nya eller ändra
            //productnamn, infotext, pris, productkategori, leverantör eller lagersaldo
            var products = Helper.GetProductsAdmin();
            var productWindow = new Classes.Window($"", 20, 5, products);
            productWindow.Draw();

            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("T. Ta bort en vara");
            Console.WriteLine("A. Ändra en vara");
            Console.WriteLine("L. lägg till en vara");
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case '1':
                    Draw.ProductPage();
                    ProductSite();
                    break;
                case '2':
                    Draw.CategoryPage();
                    CategorySite();
                    break;
                case '3':
                    Draw.UserPage();
                    UserSite();
                    break;
                case 't':
                    Draw.DrawChangeProductPage();
                    DeleteSite();
                    break;
                case 'a':
                    Draw.DrawChangeProductPage();
                    ChangeProductSite();
                    break;
                case 'l':
                    Draw.DrawChangeProductPage();
                    AddProductSite();
                    break;
            }
        }
        public static void CategorySite()
        {
            //ta bort, göra nya eller ändra
            //productnamn, infotext, pris, productkategori, leverantör eller lagersaldo
            var category = Helper.GetCategoriesAdmin();
            var productWindow = new Classes.Window($"", 20, 5, category);
            productWindow.Draw();

            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("T. Ta bort en vara");
            Console.WriteLine("A. Ändra en vara");
            Console.WriteLine("L. lägg till en vara");
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case '1':
                    Draw.ProductPage();
                    ProductSite();
                    break;
                case '2':
                    Draw.CategoryPage();
                    CategorySite();
                    break;
                case '3':
                    Draw.UserPage();
                    UserSite();
                    break;
                case 't':
                    Draw.DrawChangeCategoryPage();
                    DeleteSite();
                    break;
                case 'a':
                    Draw.DrawChangeCategoryPage();
                    ChangeCategorySite();
                    break;
                case 'l':
                    Draw.DrawChangeCategoryPage();
                    AddCategorySite();
                    break;
            }
        }
        public static void UserSite()
        {
            //ta bort, göra nya eller ändra
            //productnamn, infotext, pris, productkategori, leverantör eller lagersaldo
            var user = Helper.GetUserAdmin();
            var productWindow = new Classes.Window($"", 20, 5, user);
            productWindow.Draw();

            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("T. Ta bort en vara");
            Console.WriteLine("A. Ändra en vara");
            Console.WriteLine("L. lägg till en vara");
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case '1':
                    Draw.ProductPage();
                    ProductSite();
                    break;
                case '2':
                    Draw.CategoryPage();
                    CategorySite();
                    break;
                case '3':
                    Draw.UserPage();
                    UserSite();
                    break;
                case 't':
                    Draw.DrawChangeUserPage();
                    DeleteSite();
                    break;
                case 'a':
                    Draw.DrawChangeUserPage();
                    ChangeUserSite();
                    break;
                case 'l':
                    Draw.DrawChangeUserPage();
                    AddUserSite();
                    break;
            }
        }
        public static void DeleteSite()
        {
            var user = Helper.GetUserAdmin();
            var productWindow = new Classes.Window($"", 20, 5, user);
            productWindow.Draw();

            Console.WriteLine("Enter Id of User you would like to delete");
            int Id = int.Parse(Console.ReadLine());

            Helper.DeleteUserInfo(Id);
        }
        public static void ChangeProductSite()
        {
        }
        public static void AddProductSite()
        {
        }
        public static void ChangeCategorySite()
        {
        }
        public static void AddCategorySite()
        {
        }
        public static void ChangeUserSite()
        {
        }
        public static void AddUserSite()
        {
        }


    }
}
