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
                int LocationInfo;
                var key = Console.ReadKey();
                Console.Clear();
                switch (key.KeyChar)
                {
                    case '1':
                        LocationInfo = 1;
                        Draw.ProductPage();
                        ProductSite(LocationInfo);
                        break;
                    case '2':
                        LocationInfo = 2;
                        Draw.CategoryPage();
                        ProductSite(LocationInfo);
                        break;
                    case '3':
                        LocationInfo = 3;
                        Draw.UserPage();
                        ProductSite(LocationInfo);
                        break;
                    case 'L':
                        LoginSettnings.Logout();
                        admin = false;
                        Draw.DrawLogIn();
                        break;
                }
            }
        }
        public static void ProductSite(int Location)
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
            //switch (key.KeyChar)
            //{
            //    case '1':
            //        Draw.ProductPage();
            //        ProductSite();
            //        break;
            //    case '2':
            //        Draw.CategoryPage();
            //        ProductSite();
            //        break;
            //    case '3':
            //        Draw.UserPage();
            //        ProductSite();
            //        break;
            //    case 't':
            //        Draw.DrawDeleteProductPage();
            //        DeleteProductSite();
            //        break;
            //    case 'a':
            //        Draw.DrawChangeProductPage();
            //        ChangeProductSite();
            //        break;
            //    case 'l':
            //        Draw.DrawAddProductPage();
            //        AddProductSite();
            //        break;
            //}
        }
        public static void DeleteProductSite()
        {

        }
        public static void ChangeProductSite()
        {

        }
        public static void AddProductSite()
        {

        }
        
        
    }
}
