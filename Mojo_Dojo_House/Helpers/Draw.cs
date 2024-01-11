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
            //lägg databas istället
            List<string> categoriesText = new List<string> { "Lego", "Drones", "Nerf", "Board Games", "Collection Items" };


            //använda databas för varukorg
            List<string> cartText = new List<string> { "1 st Blå byxor", "1 st Grön tröja", "1 st Röd skjorta" };
            var windowCart = new Classes.Window("Din varukorg", 60, 8, cartText);
            windowCart.Draw();

            //använda databas för recommended
            List<string> recommended = new List<string> { "Legoset", "NerfGun", "Stordrönare" };
            var recommendedText = new Classes.Window("Recommended Products", 2, 7, recommended);
            recommendedText.Draw();

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

            List<string> Betala = new List<string> { "Vad vill du betala med", "Bankkort", "Swish", "Klarna" };
            var BetalaWindow = new Classes.Window("betala", 30, 6, Betala);
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

        public static void DrawCategories(string categories, int categoriesId)
        {
            string category = categories;
            var categoryId = categoriesId;

            //List<string> cardsText = new List<string> { category };
            //var cardText = new Classes.Window("Du är i Kategorin", 2, 6, cardsText);
            //cardText.Draw();

            var ConnectDatabase = "Server=.\\SQLExpress;Database=ToyStoreTesting;Trusted_Connection = True; TrustServerCertificate = True; ";
            var products = Helper.GetProducts(ConnectDatabase, categoryId);
            var productWindow = new Classes.Window($"kategori: {category}", 20, 5, products);
            productWindow.Draw();

            WelcomeSign();

            Categories();

            LoginSettnings.LoginBox();
        }
        public static void AdminPage()
        {
            //kunna ändra producter
            //kolla betällningshistorik
            //ändra uppgifter på kunder
            //ändra kategorier

            List<string> topText2 = new List<string> { "1:Producter  2:Kategorier  3:Kunder" };
            var windowTop2 = new Classes.Window("", 20, 1, topText2);
            windowTop2.Draw();

            WelcomeSign();
            LoginSettnings.LoginBox();


        }
        public static void WelcomeSign()
        {
            List<string> topText = new List<string> { "# Mojo Dojo #", "Här har vi kul" };
            var windowTop = new Classes.Window("", 2, 1, topText);
            windowTop.Draw();
        }

        public static void Categories()
        {
            List<string> topText2 = new List<string> { "1:Lego  2:Drones  3: Nerf  4: Board Games  5:Collection Items" };
            var windowTop2 = new Classes.Window("", 20, 1, topText2);
            windowTop2.Draw();
        }



    }
}
