using Microsoft.Data.SqlClient;
using Mojo_Dojo_House.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojo_Dojo_House.Classes;

namespace Mojo_Dojo_House.Helpers
{
    internal class Helper
    {
        public static double CalculateOrderTotal(MyDbContext myDb, int[] productIds, int[] quantities, List<OrderDetail> orderDetails)
        {
            double totalPrice = 0;
            for (int i = 0; i < productIds.Length; i++)
            {
                var product = myDb.Product.SingleOrDefault(p => p.Id == productIds[i]);
                if (product != null)
                {
                    totalPrice += product.Price * quantities[i];
                    orderDetails.Add(new OrderDetail { ProductId = productIds[i], Quantity = quantities[i] });
                }
            }
            return totalPrice;
        }

        public static void CreateAndSaveOrder(MyDbContext myDb, int userId, double totalPrice, List<OrderDetail> orderDetails)
        {
            var order = new Order { UserId = userId, TotalPrice = totalPrice, CurrentDate = DateTime.Now, OrderDetails = orderDetails };
            myDb.Add(order);
            myDb.SaveChanges();
        }
        public static List<string> GetProducts(string ConnectDatabase, int categoryId)
        {
            var products = new List<string>();

            using (SqlConnection connection = new SqlConnection(ConnectDatabase))
            {
                connection.Open();
                var query = "SELECT Name FROM Product WHERE CategoryId = @CategoryId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            return products;
        }
        public static void AdminSite()
        {
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case '1':
                    Draw.ProductPage();
                    break;
                case '2':
                    Draw.CategoryPage();
                    break;
                case '3':
                    Draw.UserPage();
                    break;
                case 'L':
                    LoginSettnings.Logout();
                    Draw.DrawLogIn();
                    break;
            }
        }
        public static void ProductSite()
        {
            //ta bort, göra nya eller ändra
            //productnamn, infotext, pris, productkategori, leverantör eller lagersaldo
        }
        public static void CategorySite()
        {
            //kunna lägga till/ta bort kategorier eller ändra namn eller description
        }
        public static void UserSite()
        {
            // kinnda lägga till, ta bort eller ändra kunder upggifter
            //kunna se beställning historik
        }
    }
    public static class LoginSettnings
    {
        public static bool IsUserLoggedIn { get; private set; } = false;
        public static string Username { get; private set; }

        public static void Login(string name)
        {
            Username = name;
            IsUserLoggedIn = true;
        }

        public static void Logout()
        {
            Username = null;
            IsUserLoggedIn = false;
        }

        public static void LoginBox()
        {
            bool isLoggedIn = LoginSettnings.IsUserLoggedIn;

            if (isLoggedIn == true)
            {
                //fixa så när man loggar in så står det att man är inloggad
                List<string> LogIn = new List<string> { LoginSettnings.Username };
                var windowLogIn = new Classes.Window("", 2, 4, LogIn);
                windowLogIn.Left = 70;
                windowLogIn.Draw();
            }
            else
            {
                List<string> LogIn = new List<string> { "L: Login" };
                var windowLogIn = new Classes.Window("", 2, 4, LogIn);
                windowLogIn.Left = 70;
                windowLogIn.Draw();
            }
        }
    }
}
