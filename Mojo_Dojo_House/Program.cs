using Mojo_Dojo_House.Helpers;
using Mojo_Dojo_House.DataInput;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Azure.Core;

namespace Mojo_Dojo_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var inputData = new InputData(); ;
            //inputData.DataInfo2();
            //inputData.DataInfo4();
            //inputData.DataInfo5();
            Draw.DrawStartMenu();
            int locationInfo = 0;
            string item = "";
            int itemId = 999;
            while (true)
            {
                var key = Console.ReadKey();
                Console.Clear();
                switch (key.KeyChar)
                {
                    case '1':
                        locationInfo = Helper.GetCategoryId(1);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '2':
                        locationInfo = Helper.GetCategoryId(2);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '3':
                        locationInfo = Helper.GetCategoryId(3);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '4':
                        locationInfo = Helper.GetCategoryId(4);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '5':
                        locationInfo = Helper.GetCategoryId(5);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case 'q':
                        item = Helper.GetProductInfo(locationInfo, 0);
                        itemId = Helper.GetItemId(item);
                        Draw.DrawProducts(itemId, item);
                        break;
                    case 'w':
                        item = Helper.GetProductInfo(locationInfo, 1);
                        itemId = Helper.GetItemId(item);
                        Draw.DrawProducts(itemId, item);
                        break;
                    case 'e':
                        item = Helper.GetProductInfo(locationInfo, 2);
                        itemId = Helper.GetItemId(item);
                        Draw.DrawProducts(itemId, item);
                        break;
                    case 'r':
                        item = Helper.GetProductInfo(locationInfo, 3);
                        itemId = Helper.GetItemId(item);
                        Draw.DrawProducts(itemId, item);
                        break;
                    case 'b':
                        double price = Helper.GetItemPrice(itemId);
                        Helper.addProductShoppingCart(price, itemId);
                        Draw.DrawProducts(itemId, item);
                        break;
                    case 'v':
                        Draw.DrawVaruKorg();
                        break;
                    case 'a':

                        //ändra antal produkter
                        break;
                    case 'd':
                        //ta bort en produkt/flera prdukter
                        break;
                    case 'f':
                        //faktura
                        break;
                    case 'l':
                        Draw.DrawLogIn();
                        Login.LoginAttempt();
                        break;
                    case 'm':
                        Draw.DrawStartMenu();
                        break;
                    case 's':
                        //Helper.Desc();
                        //Helper.Search();
                        break;
                    default:
                        Draw.DrawStartMenu();
                        break;

                }
            }
        }
    }
}
