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

        public static string GetProductInfo(int categoryID, int Keypress)
        {
            int i = Keypress;
            var Product = new List<string>();
            using (var db = new MyDbContext())
            {
                var products = db.Product.Where(c => c.CategoryId == categoryID).ToList();
                foreach (var product in products)
                {
                    Product.Add(product.Name);
                }

                string item = Product[i];

                return item;
            }
        }

        public static int GetItemId(string productName)
        {
            var Product = new List<int>();
            using (var db = new MyDbContext())
            {
                var products = db.Product.Where(c => c.Name == productName).ToList();
                foreach(var product in products)
                {
                    Product.Add(product.Id);
                }

                int itemId = Product[0];

                return itemId;
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
        public static void Desc(int itemId)
        {
            int choice = itemId;
            using (var db = new MyDbContext())
            {
                // Load products from the database
                var products = db.Product.ToList();


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
                Console.WriteLine($"Product {id} has been deleted");
                Thread.Sleep(1000);
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

                    if (user.Card != null)
                    {
                        db.Card.Remove(user.Card);
                    }

                    db.Users.Remove(user);

                    db.SaveChanges();
                }
                Console.WriteLine($"User {id} has now been deleted");
                Thread.Sleep(1000);
            }
        }

        public static void testchanges()
        {
            using (var db = new MyDbContext())
            {
                Console.WriteLine("Ange namn på personen du vill ändra info om: ");

                var inputName = int.Parse(Console.ReadLine());

                var makeChanges = (from p in db.Person
                                   where p.Id == inputName
                                   select p).SingleOrDefault();



                if (makeChanges != null)
                {
                    Console.WriteLine("Ange nytt telefonnummer: ");
                    string answer = Console.ReadLine();

                    makeChanges.PhoneNumber = answer;
                }
                 
                db.SaveChanges();
            }
        }
        public static List<string> CategoryUpdating()
        {
            var Categories = new List<string>();
            var i = 1;
            using (var db = new MyDbContext())
            {
                foreach (var name in db.Category)
                {
                    string category = i + ". " + name.Name;
                    Categories.Add(category);
                    i++;
                }
            }
            return Categories;
        }

        //needs fixing
        //public static List<string> ProductUpdating()
        //{
        //    var Products = new List<string>();
        //    List<string> key = new List<string> {"Q: ", "W: ", "E: ", "R: ", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",  "",};
        //    using (var db = new MyDbContext())
        //    {
        //        foreach (var name in db.Product)
        //        {
        //            string product = key + "." + name.Name;
        //        }
        //    }
        //    return Products;
        //}

        public static void GetCategory(int num)
        {
            var i = num;
            using (var db = new MyDbContext())
            {
                var category = new List<string>();
                var categories = from c in db.Category
                                  where c.Name != null 
                                  orderby c.Id
                                  select c;
                categories.ToList();

                foreach (var c in categories)
                {
                    category.Add(c.Name);
                }
                Console.WriteLine(category[i]);

                
            }
        }
        public static int GetCategoryId(int num)
        {
            var i = num;
            using (var db = new MyDbContext())
            {
                var category = new List<int>();
                var categories = from c in db.Category
                                 where c.Id != null
                                 orderby c.Id
                                 select c;
                categories.ToList();

                foreach (var c in categories)
                {
                    category.Add(c.Id);
                }

                int Number = category[i];
                return Number;
            }
        }

        public static void AddUserInfo()
        {

            Console.WriteLine("city");
            string city = Console.ReadLine();
                             
            Console.WriteLine("street");
            string street = Console.ReadLine();

            Console.WriteLine("country");
            string country = Console.ReadLine();

            Console.WriteLine("zipcode");
            string zipcode = Console.ReadLine();

            using (var db = new MyDbContext())
            {
                var newAddress = new Address { City = city, Street = street, Country = country, Zipcode = zipcode };
                db.Address.Add(newAddress);
                db.SaveChanges();
            }
            Console.WriteLine("firstname");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last name");
            string lastName = Console.ReadLine();

            Console.WriteLine("phonenumber");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("email");
            string email = Console.ReadLine();

            Console.WriteLine("age");
            int age = int.Parse(Console.ReadLine());



            using (var db = new MyDbContext())
            {
                int adressId = 14;
                var newPerson = new Person { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email, Age = age, AddressId = adressId };

                db.Person.Add(newPerson);
                db.SaveChanges();

            }

            Console.WriteLine("cardnumber");
            string cardNumber = Console.ReadLine();



            using (var db = new MyDbContext())
            {
                int personId = 11;
                var newCard = new Card { CardNumber = cardNumber, PersonId = personId };
                db.Card.Add(newCard);
                db.SaveChanges();
            }
            Console.WriteLine("UserName");
            string userName = Console.ReadLine();

            Console.WriteLine("password");
            string passWord = Console.ReadLine();


            
            using (var db = new MyDbContext())
            {
                int personId = 11;
                int cardId = 11;
                var newUser = new User { Username = userName, Password = passWord, PersonId = personId, CardId = cardId };

                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
    }
}
