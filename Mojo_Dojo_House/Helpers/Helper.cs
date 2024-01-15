using Microsoft.Data.SqlClient;
using Mojo_Dojo_House.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojo_Dojo_House.Classes;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Mojo_Dojo_House.DataInput;

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

        public static List<string> GetProducts(int categoryID)
        {
            var Product = new List<string>();
            using (var db = new MyDbContext())
            {
                var products = db.Product.Where(c => c.CategoryId == categoryID).ToList();
                foreach (var product in products)
                {
                    Product.Add(product.Name);
                }
                return Product;
            }
        }



        public static void Search()
        {
            Console.WriteLine("Sök: ");
            string searchTerm = Console.ReadLine();

            using (var db = new MyDbContext())
            {
                var search = db.Product
                                 .Where(c => c.Name.Contains(searchTerm) || c.Description.Contains(searchTerm))
                                 .ToList();

                foreach (var toy in search)
                {
                    Console.WriteLine(toy.Name);
                }
            }
        }
        public static List<string> GetRecommended()
        {
            
            using (var db = new MyDbContext())
            {
                var Recommend = new List<string>();
                var recommended = from r in db.Product
                                  where r.Recommended == true
                                  orderby r.Name
                                  select r;
                recommended.ToList();


                foreach (var r in recommended)
                {
                    Recommend.Add(r.Name);
                    
                }
                return Recommend;
            }

        }
        public static List<string> GetProductsAdmin()
        {
            var products = new List<string>();
            using (var db = new MyDbContext())
            {
                foreach(var name in db.Product)
                {
                    string product = name.Id + ". " + name.Name;
                    products.Add(product);
                }
            }
           return products;
        }


        public static List<string> GetCategoriesAdmin()
        {
            var Categories = new List<string>();
            using (var db = new MyDbContext())
            {
                foreach (var name in db.Category)
                {
                    string category = name.Id + ". " + name.Name;
                    Categories.Add(category);
                }
            }
            return Categories;
        }

        public static List<string> GetUserAdmin()
        {
            var Users = new List<string>();
            using (var db = new MyDbContext())
            {
                foreach (var user in db.Users)
                {
                    string User = user.Id + ". " + user.Username;
                    Users.Add(User);
                    
                }
            }
            return Users;
        }
    }
}
