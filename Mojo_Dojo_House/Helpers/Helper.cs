using Microsoft.Data.SqlClient;
using Mojo_Dojo_House.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojo_Dojo_House.Classes;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
            var CategoryId = categoryId;
            using (SqlConnection connection = new SqlConnection(ConnectDatabase))
            {
                connection.Open();
                var query = $"SELECT Name FROM Product WHERE CategoryId = {CategoryId}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
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

        public static List<string> GetProductsAdmin()
        {
            var products = new List<string>();
            using (var db = new MyDbContext())
            {
                foreach(var name in db.Product)
                {
                    products.Add(name.Name);
                }
            }
           return products;
        }


        public static List<string> GetCategoriesAdmin(string ConnectDatabase)
        {
            var categories = new List<string>();

            using (var connection = new SqlConnection(ConnectDatabase))
            {
                connection.Open();
                var query = "Select Name FROM Category";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            return categories;
        }
    }
}
