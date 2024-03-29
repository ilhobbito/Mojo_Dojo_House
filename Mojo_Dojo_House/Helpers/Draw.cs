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
            var recommended = Helper.GetRecommended(); 
            var recommendedText = new Classes.Window("Rekommenderade produkter", 60, 8, recommended);
            recommendedText.Draw();

            ShowShoppingCart();

            WelcomeSign();

            Categories();

            Login.LoginBox();
        }

        public static void DrawVaruKorg()
        {


            ShoppingCart();

            double TotalPrice = Helper.CalculateShoppingCart();
            var totalPrice = new List<string>();

            
            string formateratPris = TotalPrice.ToString("0.00 kr");
            totalPrice.Add(formateratPris);

            var Price = new Classes.Window("Totalpris utan moms: ", 40, 15, totalPrice);
            Price.Draw();
            List<string> cardsText = new List<string> {"F: För att välja leverans", "A: För att ändra antal varor", "D: för att ta bort en vara"};
            var faktura = new Classes.Window("", 2, 15, cardsText);
            faktura.Draw();
            WelcomeSign();
                
            Categories();

            Login.LoginBox();
        } 
        public static void DrawPayment(char key)
        {
            int deliveryCost = 0;
            if (key == 'p')
            {
                deliveryCost = 39;
            }    
            else if (key == 'o')
            {
                deliveryCost = 49;
            }
            else
            {

            }

            ShoppingCart();

            double TotalPrice = Helper.CalculateShoppingCart();
            TotalPrice = TotalPrice * 1.25 + deliveryCost;
            var totalPrice = new List<string>();

            string formateratPris = TotalPrice.ToString("0.00 kr");
            totalPrice.Add(formateratPris);
            var Price = new Classes.Window("Totalpris med moms: ", 40, 15, totalPrice);
            Price.Draw();

            List<string> Betala = new List<string> { "Vad vill du betala med", "H: Bankkort", "J: Swish", "K: Klarna" };
            var BetalaWindow = new Classes.Window("Betala", 60, 9, Betala);
            BetalaWindow.Draw();

            WelcomeSign();

            Categories();

            Login.LoginBox();
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

            Login.LoginBox();
        }
        public static void DrawLogIn()
        {
            WelcomeSign();

            Login.LoginBox();
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
            int category = categoriesId;

            var products = Helper.GetProducts(category);
            var productWindow = new Classes.Window($"kategori:", 40, 5, products);
            productWindow.Draw();


            //fick problem att lägga knapparna i samma namn som produkterna
            List<string> topText2 = new List<string> { "Q:", "W:", "E:", "R" };
            var window = new Classes.Window($"", 33, 5, topText2);
            window.Draw();

            ShowShoppingCart();

            WelcomeSign();

            Categories();

            Login.LoginBox();
        }
        public static void DrawProducts(int productId, string item, string Price)
        {

            List<string> topText2 = new List<string> { };
            topText2.Add(item);

            var windowTop2 = new Classes.Window("", 20, 1, topText2);
            windowTop2.Draw();

            List<string> topText3 = new List<string> { };
            topText3.Add(Price);
            var windowTop3 = new Classes.Window("", 30, 10, topText3);
            windowTop3.Draw();

            List<string> topText = new List<string> { "B: Köp produkt" };
            var windowTop = new Classes.Window("", 50, 10, topText);
            windowTop.Draw();

            Helper.Desc(productId);

            ShowShoppingCart();

            WelcomeSign();

            Categories();

            Login.LoginBox();
        }
        public static void AdminPage()
        {
            AdminBanner();
            WelcomeSign();
        }

        public static void AdminProducts()
        {
            var products = Helper.GetProductsAdmin();
            var windowTop = new Classes.Window("", 50, 10, products);
            windowTop.Draw();

            List<string> topText3 = new List<string> { "A: lägg till en ny produkt", "S: Ändra en produkt", "D: Ta bort en produkt" };
            var windowTop3 = new Classes.Window("", 10, 15, topText3);
            windowTop3.Draw();

            AdminBanner();
            WelcomeSign();

        }
        public static void Delivery()
        {
            List<string> topText2 = new List<string> { "Postnord 39kr: P", "Early bird 49: O"};
            var window = new Classes.Window($"", 33, 5, topText2);
            window.Draw();

            WelcomeSign();
            Categories();

        }
        public static void AdminCategories()
        {
            var category = Helper.GetCategoriesAdmin();
            var windowTop = new Classes.Window("", 50, 10, category);
            windowTop.Draw();
            var unsorted = Helper.GetUnsortedItems();
            var stringUnsorted = new List<string> {unsorted.ToString()};

            var windowTop2 = new Classes.Window("Hur många osorterade produkter", 10, 10, stringUnsorted);
            windowTop2.Draw();
            AdminBanner();
            WelcomeSign();

            List<string> topText3 = new List<string> { "A: lägg till en ny kategori", "S: Ändra en kategori", "D: Ta bort en kategori"};
            var windowTop3 = new Classes.Window("", 10, 15, topText3);
            windowTop3.Draw();
        }
        public static void AdminUsers()
        {
            var user = Helper.GetUserAdmin();
            var windowTop = new Classes.Window("", 50, 10, user);
            windowTop.Draw();
            List<string> topText3 = new List<string> { "A: lägg till en ny användare", "S: Ändra en användare", "D: Ta bort en användare" };
            var windowTop3 = new Classes.Window("", 10, 15, topText3);
            windowTop3.Draw();
            AdminBanner();
            WelcomeSign();
        }   
        public static void AdminOrderInfo()
        {
            var OrderHistory = Helper.GetOrderHistory();
            var windowTop = new Classes.Window("", 50, 10, OrderHistory);
            windowTop.Draw();
            AdminBanner();
            WelcomeSign();
        }
        public static void AdminBanner()
        {
            List<string> topText2 = new List<string> { "1:Produkter  2:Kategorier  3:Kunder 4:BetalningsHistorik 5: Queries" };
            var windowTop2 = new Classes.Window("", 20, 1, topText2);
            windowTop2.Draw();

            WelcomeSign();
        }

        public static void DrawQuieries()
        {
            AdminBanner();
            WelcomeSign();
            Helper.CallQueries();  
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

            var windowTop2 = new Classes.Window("S: Söka", 2, 6, topText2);
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
        public static void ShoppingCart()
        {
            var product = new List<string> { };
            product = Helper.GetShoppingCart();
            var productWindow = new Classes.Window($"Varukorg", 30, 4, product);
            productWindow.Draw();
        }

        public static void ShowShoppingCart()
        {
            var product = Helper.GetShoppingCartCount();
            List<string> NumOfProducts = new List<string>();
            var stringproduct = product.ToString();
            NumOfProducts.Add(stringproduct);
            var productWindow = new Classes.Window($"V: Varukorg", 85, 1, NumOfProducts);
            productWindow.Draw();
        }
    }
}
