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
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

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
        public static void Desc()
        {
            using (var db = new MyDbContext())
            {
                // Load products from the database
                var products = db.Product.ToList();

                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());

                if (choice >= 1 && choice <= products.Count)
                {
                    Product selectedProduct = products[choice - 1];
                    Console.WriteLine(selectedProduct.Description);
                }
                else
                {
                    Console.WriteLine("Invalid choice");
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
                foreach (var name in db.Product)
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

        public static void DeleteProductInfo(int id)
        {
            using (var db = new MyDbContext())
            {
                var product = db.Product.FirstOrDefault(p => p.Id == id);

                if (product != null)
                {
                    db.Product.Remove(product);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteCategoryInfo(int id)
        {
            using (var db = new MyDbContext())
            {
                var category = db.Category.FirstOrDefault(p => p.Id == id);

                if (category != null)
                {
                    db.Category.Remove(category);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteUserInfo(int id)
        {
            int userId = id;
            using (var db = new MyDbContext())
            {
                var user = db.Users.Include(u => u.Person).ThenInclude(p => p.Address)
                                  .Include(u => u.Card)
                                  .FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    if (user.Person != null)
                    {
                        if (user.Person.Address != null)
                        {
                            db.Address.Remove(user.Person.Address);
                        }
                        db.Person.Remove(user.Person);
                    }

                    // If the user has a linked card, delete it
                    if (user.Card != null)
                    {
                        db.Card.Remove(user.Card);
                    }

                    // Finally, delete the user
                    db.Users.Remove(user);

                    // Save the changes to the database
                    db.SaveChanges();
                }
                Console.WriteLine($"User {id} has now been deleted");
                Thread.Sleep(1000);
            }
        }
    }
}
