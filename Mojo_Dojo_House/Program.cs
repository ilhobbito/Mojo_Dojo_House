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
            //var inputData = new InputData();
            //inputData.DataInfo1();
            //inputData.DataInfo2();
            //inputData.DataInfo3();
            //inputData.DataInfo4();
            //inputData.DataInfo5();
            Draw.DrawStartMenu();
            int locationInfo = 0;
            string item;
            int itemId;
            while (true)
            {
                var key = Console.ReadKey();
                Console.Clear();
                switch (key.KeyChar)
                {
                    case '1':
                        Helper.GetCategory(0);
                        locationInfo = Helper.GetCategoryId(0);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '2':
                        Helper.GetCategory(1);
                        locationInfo = Helper.GetCategoryId(1);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '3':
                        Helper.GetCategory(2);
                        locationInfo = Helper.GetCategoryId(2);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '4':
                        Helper.GetCategory(3);
                        locationInfo = Helper.GetCategoryId(3);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '5':
                        Helper.GetCategory(4);
                        locationInfo = Helper.GetCategoryId(4);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case 'q':
                        item = Helper.GetProductInfo(locationInfo, 1);
                        itemId = Helper.GetItemId(item);
                        //fixa med en draw. för att rita ut en okej bild
                        Console.WriteLine(item);
                        Helper.Desc(itemId);
                        break;
                    case 'w':
                        item = Helper.GetProductInfo(locationInfo, 2);
                        itemId = Helper.GetItemId(item);
                        Console.WriteLine(item);
                        Helper.Desc(itemId);
                        break;
                    case 'e':
                        item = Helper.GetProductInfo(locationInfo, 3);
                        itemId = Helper.GetItemId(item);
                        Console.WriteLine(item);
                        Helper.Desc(itemId);
                        break;
                    case 'r':
                        item = Helper.GetProductInfo(locationInfo, 4);
                        itemId = Helper.GetItemId(item);
                        Console.WriteLine(item);
                        Helper.Desc(itemId);
                        break;
                    case 'b':
                        
                    case 'v':
                        Draw.DrawVaruKorg();
                        Varukorg.ShoppingCart();
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
