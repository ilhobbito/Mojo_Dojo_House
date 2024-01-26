using Mojo_Dojo_House.Helpers;
using Mojo_Dojo_House.DataInput;


namespace Mojo_Dojo_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Databas inmatning
            //först: update-database
            //Ta bort kommentarena på inputdata första gången den körs och sen kommentera ut för att inte få upprepad data
            //ifall data inte finns i databasen så crashar det

            //var inputData = new InputData();
            //inputData.DataInfo2();
            //inputData.DataInfo4();
            //inputData.DataInfo5();




            int j = 1; //så man trackar hur många köp i den session
            int newPerson = 1;
            Draw.DrawStartMenu();
            int locationInfo = 0;
            char keypress;
            string item = "";
            int itemId = 999;
            string stringPrice = "";
            while (true)
            {
                var key = Console.ReadKey();
                Console.Clear();
                switch (char.ToLower(key.KeyChar))
                {
                    case '1':
                        locationInfo = Helper.GetCategoryId(0);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '2':
                        locationInfo = Helper.GetCategoryId(1);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '3':
                        locationInfo = Helper.GetCategoryId(2);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '4':
                        locationInfo = Helper.GetCategoryId(3);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case '5':
                        locationInfo = Helper.GetCategoryId(4);
                        Draw.DrawCategories(locationInfo);
                        break;
                    case 'q':
                        item = Helper.GetProductInfo(locationInfo, 0);
                        stringPrice = Helper.GetProductPrice(locationInfo, 0);
                        itemId = Helper.GetItemId(item);
                        Draw.DrawProducts(itemId, item, stringPrice);
                        break;
                    case 'w':
                        item = Helper.GetProductInfo(locationInfo, 1);
                        stringPrice = Helper.GetProductPrice(locationInfo, 1);
                        itemId = Helper.GetItemId(item);
                        Draw.DrawProducts(itemId, item, stringPrice);
                        break;
                    case 'e':
                        item = Helper.GetProductInfo(locationInfo, 2);
                        stringPrice = Helper.GetProductPrice(locationInfo, 2);
                        itemId = Helper.GetItemId(item);
                        Draw.DrawProducts(itemId, item, stringPrice);
                        break;
                    case 'r':
                        item = Helper.GetProductInfo(locationInfo, 3);
                        stringPrice = Helper.GetProductPrice(locationInfo, 3);
                        itemId = Helper.GetItemId(item);
                        Draw.DrawProducts(itemId, item, stringPrice);
                        break;
                    case 'b':
                        double price = Helper.GetItemPrice(itemId);
                        Helper.addProductShoppingCart(price, itemId);
                        Draw.DrawProducts(itemId, item, stringPrice);
                        Console.WriteLine($"En produkt har lagts till i varukorgen {j}");
                        j++;
                        break;
                    case 'v':
                        Draw.DrawVaruKorg();
                        break;
                    case 'a':
                        Draw.DrawVaruKorg();
                        Console.WriteLine("Vilken produkt vill du ändra?(Id): ");
                        int productId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Hur många vill du ändra till?");
                        int quantity = int.Parse(Console.ReadLine());
                        Helper.ChangeShoppingCartQuantity(productId, quantity);
                        Console.Clear();
                        Draw.DrawVaruKorg();
                        break;
                    case 'd':
                        Draw.DrawVaruKorg();
                        Console.WriteLine("Vilken produkt vill du ta bort?(Id): ");
                        int productId1 = int.Parse(Console.ReadLine());

                        Helper.DeleteShoppingCart(productId1);
                        Console.Clear();
                        Draw.DrawVaruKorg();
                        break;
                    case 'p':
                        keypress = 'p';
                        Draw.DrawPayment(keypress);
                        break;
                    case 'o':
                        keypress = 'o';
                        Draw.DrawPayment(keypress);
                        break;
                    case 'h':
                        Helper.SaveShoppingCartToOrder(newPerson);
                        Helper.DeleteCart();
                        Console.WriteLine("Nu har du betalat!");
                        break;
                    case 'j':
                        Helper.SaveShoppingCartToOrder(newPerson);
                        Helper.DeleteCart();
                        Console.WriteLine("Nu har du betalat!");
                        break;
                    case 'f':
                        newPerson = Helper.AddUserInfo();
                        Console.Clear();
                        Draw.Delivery();
                        break;
                    case 'k':
                        Helper.SaveShoppingCartToOrder(newPerson);
                        Helper.DeleteCart();
                        Console.WriteLine("Nu har du betalat!");
                        break;
                    case 'l':
                        Draw.DrawLogIn();
                        Login.LoginAttempt();
                        break;
                    case 'm':
                        Draw.DrawStartMenu();
                        break;
                    case 's':
                        Helper.Search();
                        break;
                    default:
                        Draw.DrawStartMenu();
                        break;

                }
            }
        }
    }
}
