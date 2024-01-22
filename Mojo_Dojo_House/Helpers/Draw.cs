using Mojo_Dojo_House.Helpers;
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

            LoginSettnings.LoginBox();
        }

        public static void DrawVaruKorg()
        {


            ShoppingCart();

            double TotalPrice = Helper.CalculateShoppingCart();
            var totalPrice = new List<string>();

            totalPrice.Add(TotalPrice.ToString());

            var Price = new Classes.Window("TotalPris: ", 40, 15, totalPrice);
            Price.Draw();

            //List<string> frakt = new List<string> { "Välj fraktsätt med: Ombud eller Postnord, tryck O för Ombud, P för Postnord " };
            //var shippingInfo = new Classes.Window("Ombud: ", 25, 6, frakt);
            //shippingInfo.Draw();

            //List<string> Betala = new List<string> { "Vad vill du betala med", "Bankkort", "Swish", "Klarna" };
            //var BetalaWindow = new Classes.Window("betala", 30, 9, Betala);
            //BetalaWindow.Draw();

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
            int category = categoriesId;

            var products = Helper.GetProducts(category);
            var productWindow = new Classes.Window($"kategori:", 40, 5, products);
            productWindow.Draw();

            List<string> topText2 = new List<string> { "Q:", "W:", "E:", "R" };
            var window = new Classes.Window($"", 33, 5, topText2);
            window.Draw();

            ShowShoppingCart();

            WelcomeSign();

            Categories();

            LoginSettnings.LoginBox();
        }
        public static void DrawProducts(int productId, string item)
        {
            int product = productId;
            string toy = item;
            List<string> topText2 = new List<string> { };
            topText2.Add(toy);

            var windowTop2 = new Classes.Window("", 20, 1, topText2);
            windowTop2.Draw();

            List<string> topText = new List<string> { "B: Buy Product" };
            var windowTop = new Classes.Window("", 50, 10, topText);
            windowTop.Draw();

            Helper.Desc(product);

            ShowShoppingCart();

            WelcomeSign();

            Categories();

            LoginSettnings.LoginBox();
        }
        public static void AdminPage()
        {
            AdminBanner();
            WelcomeSign();
            LoginSettnings.LoginBox();
        }

        public static void AdminProducts()
        {
            var products = Helper.GetProductsAdmin();
            var windowTop = new Classes.Window("", 50, 10, products);
            windowTop.Draw();

            AdminBanner();
            WelcomeSign();
            LoginSettnings.LoginBox();
        }
        public static void AdminCategories()
        {
            var category = Helper.GetCategoriesAdmin();
            var windowTop = new Classes.Window("", 50, 10, category);
            windowTop.Draw();
            var unsorted = Helper.GetUnsortedItems();
            var windowTop2 = new Classes.Window("Num of unsorted products", 10, 10, unsorted);
            windowTop2.Draw();
            AdminBanner();
            WelcomeSign();
            LoginSettnings.LoginBox();
        }
        public static void AdminUsers()
        {
            var user = Helper.GetUserAdmin();
            var windowTop = new Classes.Window("", 50, 10, user);
            windowTop.Draw();
            AdminBanner();
            WelcomeSign();
            LoginSettnings.LoginBox();
        }   
        public static void AdminOrderInfo()
        {
            var OrderHistory = Helper.GetOrderHistory();
            var windowTop = new Classes.Window("", 50, 10, OrderHistory);
            windowTop.Draw();
            AdminBanner();
            WelcomeSign();
            LoginSettnings.LoginBox();
        }
        public static void AdminBanner()
        {
            List<string> topText2 = new List<string> { "1:Produkter  2:Kategorier  3:Kunder" };
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
        public static void ShoppingCart()
        {
            var product = Helper.GetShoppingCard();
            var productWindow = new Classes.Window($"Varukorg", 30, 4, product);
            productWindow.Draw();
        }
        public static void ShowShoppingCart()
        {
            var product = Helper.GetShoppingCartCount();
            List<string> NumOfProducts = new List<string>();
            var stringproduct = product.ToString();
            NumOfProducts.Add(stringproduct);
            var productWindow = new Classes.Window($"Varukorg", 82, 1, NumOfProducts);
            productWindow.Draw();
        }
    }
}
