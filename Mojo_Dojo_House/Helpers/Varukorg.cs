using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojo_Dojo_House.Helpers
{
    internal class Varukorg
    {
        public static void ShoppingCart()
        {
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                //varukorg
                case '1':
                    //kategori 1
                    string category1 = "Lego";
                    int category1Id = 1;
                    Draw.DrawCategories(category1, category1Id);
                    break;
                case '2':
                    string category2 = "Drones";
                    int category2Id = 2;
                    Draw.DrawCategories(category2, category2Id);
                    //Kategori 2
                    break;
                case '3':
                    string category3 = "Nerf";
                    int category3Id = 3;
                    Draw.DrawCategories(category3, category3Id);
                    //Kategori 3
                    break;
                case '4':
                    string category4 = "Board Games";
                    int category4Id = 4;
                    Draw.DrawCategories(category4, category4Id);
                    //Kategori 4
                    break;
                case '5':
                    string category5 = "Collection Items";
                    int category5Id = 5;
                    Draw.DrawCategories(category5, category5Id);
                    break;
                case 'b':
                    string card1 = "B: Bankkort";
                    Paying(card1);
                    break;
                case 's':
                    string card2 = "S: Swish";
                    Paying(card2);
                    break;
                case 'k':
                    string card3 = "K: Klarna";
                    Paying(card3);
                    break;

                case 'o':
                    string shipping1 = "O: Ombud";
                    Draw.DrawShipping(shipping1);
                    Shipping(shipping1);
                    break;
                case 'p':
                    string shipping2 = "P: Postnord";
                    Draw.DrawShipping(shipping2);
                    Shipping(shipping2);
                    break;
                case 'l':
                    Draw.DrawLogIn();
                    break;
                case 'm':
                    break;


            }
        }
        public static void Shipping(string shipping)
        {
            string shippings = shipping;
            Draw.DrawShipping(shipping);
            Console.ReadLine();
        }

            public static void Paying(string card)
        {
            string cards = card;
            Draw.DrawCard(cards);
            Console.ReadLine();
        }
    }
}
