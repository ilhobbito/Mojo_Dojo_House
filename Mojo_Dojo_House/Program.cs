using Mojo_Dojo_House.Helpers;

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
            while (true)

            {
                Console.Clear();
                Draw.DrawStartMenu();
                var key = Console.ReadKey();
                Console.Clear();
                switch (key.KeyChar)
                {
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
                        //Kategori 5
                        break;
                    case 'v':
                        Draw.DrawVaruKorg();
                        Varukorg.ShoppingCart();
                        break;
                    case 'l':
                        Draw.DrawLogIn();
                        Login.LoginAttempt();
                        break;
                    case 's':
                        break;
                }
            }
        }
    }
}
