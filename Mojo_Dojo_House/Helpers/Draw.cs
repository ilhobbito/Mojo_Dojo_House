﻿using Mojo_Dojo_House.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojo_Dojo_House.Classes;

namespace Mojo_Dojo_House.Helpers
{
    public class Draw
    {

        public static void DrawStartMenu()
        {
            List<string> cartText = new List<string> { "1 st Blå byxor", "1 st Grön tröja", "1 st Röd skjorta" };
            var windowCart = new Classes.Window("Din varukorg", 60, 8, cartText);
            windowCart.Draw();

            //var recommended = Helper.GetRecommended();
            //var recommendedText = new Classes.Window("Recommended Products", 2, 7, recommended);
            //recommendedText.Draw();

            WelcomeSign();

            Categories();

            LoginSettnings.LoginBox();
        }

        public static void DrawVaruKorg()
        {

            //använda databas för recommended
            List<string> cartText = new List<string> { "Blå byxor 1st", "Grön tröja 1sr", "Röd skjorta 1st" };
            var windowCart = new Classes.Window("Din varukorg", 2, 6, cartText);
            windowCart.Draw();

            List<string> frakt = new List<string> { "Välj fraktsätt med: Ombud eller Postnord, tryck O för Ombud, P för Postnord " };
            var shippingInfo = new Classes.Window("Ombud: ", 25, 6, frakt);
            shippingInfo.Draw();

            List<string> Betala = new List<string> { "Vad vill du betala med", "Bankkort", "Swish", "Klarna" };
            var BetalaWindow = new Classes.Window("betala", 30, 9, Betala);
            BetalaWindow.Draw();

            WelcomeSign();

            Categories();

            LoginSettnings.LoginBox();
        }
        public static void DrawCard(string card)
        {
            string cards = card;
            List<string> cardsText = new List<string> { cards };
            var cardText = new Classes.Window("Du betalar med", 2, 6, cardsText);
            cardText.Draw();

            //använd databas för information 
            List<string> UserInfo = new List<string> { };
            var UserInfoText = new Classes.Window("", 30, 6, UserInfo);

            WelcomeSign();

            Categories();

            LoginSettnings.LoginBox();
        }
        public static void DrawLogIn()
        {
            List<string> LoginInfo = new List<string> { "" };
            var Login = new Classes.Window("Ange dina inloggningsuppgifter", 2, 6, LoginInfo);
            Login.Draw();

            WelcomeSign();

            Categories();

            LoginSettnings.LoginBox();
        }
        public static void DrawShipping(string shipping)
        {

            string shippings = shipping;
            List<string> shippingsInfo = new List<string> { shippings };
            var shippingInfo = new Classes.Window("Välj fraktsätt med: ", 2, 6, shippingsInfo);
            shippingInfo.Draw();
        }
        public static void DrawCategories(int categoriesId)
        {
            //string category = categories;

            //needs fixing
            //var products = Helper.ProductUpdating();
            //var productWindow = new Classes.Window($"kategori:", 40, 5, products);
            //productWindow.Draw();

            WelcomeSign();

            Categories();

            LoginSettnings.LoginBox();
        }
        public static void AdminPage()
        {
            Console.Clear();

            List<string> topText2 = new List<string> { "1:Producter  2:Kategorier  3:Kunder" };
            var windowTop2 = new Classes.Window("", 20, 1, topText2);
            windowTop2.Draw();

            WelcomeSign();
            LoginSettnings.LoginBox();     
        }
        public static void ProductPage()
        {
            AdminBanner();
            WelcomeSign();
        }
        public static void CategoryPage()
        {
            AdminBanner();
            WelcomeSign();
        }
        public static void UserPage()
        {
            AdminBanner();
            WelcomeSign();
        }

        public static void AdminBanner()
        {
            List<string> topText2 = new List<string> { "1:Producter  2:Kategorier  3:Kunder" };
            var windowTop2 = new Classes.Window("", 20, 1, topText2);
            windowTop2.Draw();

            WelcomeSign();

            LoginSettnings.LoginBox();
        }

        public static void DrawChangeProductPage()
        {
            AdminBanner();
            WelcomeSign();
            ProductPageInfo(); 
        }

        public static void DrawChangeCategoryPage()
        {
            WelcomeSign();
            AdminBanner();
            CategoryPageInfo();
            
        }
        public static void DrawChangeUserPage()
        {
            WelcomeSign();
            AdminBanner();
            UserPageInfo();
        }

        public static void WelcomeSign()
        {
            List<string> topText = new List<string> { "# Mojo Dojo #", "Här har vi kul" };
            var windowTop = new Classes.Window("", 2, 1, topText);
            windowTop.Draw();
        }

        public static void Categories()
        {
            var topText2 = Helper.CategoryUpdating();
            
            var windowTop2 = new Classes.Window("", 2, 6, topText2);
            windowTop2.Draw();
        }

        public static void UserPageInfo()
        {
            var user = Helper.GetUserAdmin();
            var productWindow = new Classes.Window($"", 20, 5, user);
            productWindow.Draw();
        }
        public static void CategoryPageInfo()
        {
            var user = Helper.GetCategoriesAdmin();
            var productWindow = new Classes.Window($"", 20, 5, user);
            productWindow.Draw();
        }
        public static void ProductPageInfo()
        {
            var user = Helper.GetProductsAdmin();
            var productWindow = new Classes.Window($"", 20, 5, user);
            productWindow.Draw();
        }
    }
}
