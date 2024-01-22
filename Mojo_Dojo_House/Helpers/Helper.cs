﻿using Microsoft.Data.SqlClient;
using Mojo_Dojo_House.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Mojo_Dojo_House.DataInput;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Azure;
using System.Diagnostics.Metrics;
using System.IO;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace Mojo_Dojo_House.Helpers
{
    internal class Helper
    {
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

        public static int GetShoppingCartCount()
        {
            using (var db = new MyDbContext())
            {
                var Number = db.ShoppingCarts.Count();

                return Number;
            }
        }

        public static List<string> GetShoppingCard()
        {
            var product = new List<int>();
            var stringProduct = new List<string>();
            var productQuantity = new List<int>();
            var stringProductQuantity = new List<string>();
            var i = 0;
            using (var db = new MyDbContext())
            {
                var products = db.ShoppingCarts.ToList();
                foreach(var Product in products)
                {
                    product.Add(Product.productId);
                    var productId = product[i];
                    var productName = db.Product.Where(c => c.Id == productId).ToList();
                    
                    foreach(var productNames in productName)
                    {
                        stringProduct.Add(productNames.Name);

                    }
                    i++;
                    foreach(var Product1 in products)
                    {
                        productQuantity.Add(Product1.Quantity);
                    }
                }
                return stringProduct;
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
        public static double GetItemPrice(int ItemId)
        {
            double price;
            var Product = new List<double>();
            using (var db = new MyDbContext())
            {
                var products = db.Product.Where(c => c.Id == ItemId).ToList();
                foreach (var product in products)
                {
                    Product.Add(product.Price);
                }

                price = Product[0];
            }
            return price;
        }
        public static double CalculateShoppingCart()
        {
            var SumOfitem = new List<double>();
            int i = 0;
            double totalPrice = 0;
            using (var db = new MyDbContext())
            {
                var shoppingCart = db.ShoppingCarts;
                foreach (var item in shoppingCart)
                {
                    SumOfitem.Add(item.Quantity * item.TotalPrice);
                }
                foreach(var item in SumOfitem)
                {
                    totalPrice += SumOfitem[i];
                    i++;
                }
                return totalPrice;
            }
        }

        public static void addProductShoppingCart(double price, int productId)
        {
            using (var db = new MyDbContext())
            {
                var existingProduct = db.ShoppingCarts.FirstOrDefault(p => p.productId == productId);

                if (existingProduct != null)
                {
                    existingProduct.Quantity += 1;
                }
                else
                {
                    var ShoppingCart1 = new ShoppingCart { productId = productId, Quantity = 1, TotalPrice = price };
                    db.ShoppingCarts.Add(ShoppingCart1);
                }

                db.SaveChanges();
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


                    List<string> topText2 = new List<string> {};
                    topText2.Add(selectedProduct.Description);
                    var productWindow = new Classes.Window($"", 30, 6, topText2);
                    productWindow.Draw();
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
                foreach (var user in db.Person)
                {
                    string User = user.Id + ". " + user.FirstName+ " " + user.LastName ;
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
                foreach (var name in db.Category.Where(c => !c.IsDeleted).Skip(1).Take(5))
                {
                    string category = i + ". " + name.Name;
                    Categories.Add(category);
                    i++;
                }
            }
            return Categories;
        }
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
                var categories = db.Category
                                   .Where(c => c.Id != null && !c.IsDeleted && c.Name != "Uncategorised")
                                   .OrderBy(c => c.Id)
                                   .ToList();

                if (i - 1 < categories.Count)
                {
                    int Number = categories[i - 1].Id;
                    return Number;
                }
                else
                {
                    return 0;
                }

            }
        }

        public static int GetCategoryIdAdmin(string categori)
        {
            using (var db = new MyDbContext())
            {
                var category = new List<string>();
                var categories = from c in db.Category
                                 where c.Name == categori
                                 orderby c.Id
                                 select c;
                categories.ToList();

                foreach (var c in categories)
                {
                    category.Add(c.Name);
                }

                int Number = int.Parse(category[0]);
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

            Console.WriteLine("Postkod");
            string postcode = Console.ReadLine();

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
                
                var newPerson = new Person { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email, Age = age, City = city, Country = country, Street = street, PostCode = postcode};

                db.Person.Add(newPerson);
                db.SaveChanges();

            }
        }

        public static void AddProductInfo()
        {
            int categoryId = 0;
            Console.WriteLine("Namn: ");
            string name = Console.ReadLine();

            Console.WriteLine("kategori: ");
            CategoryUpdating();
            string category = Console.ReadLine();
            category = char.ToUpper(category[0]) + category[1..].ToLower();

            if (category == "Lego")
            {
                categoryId=Helper.GetCategoryIdAdmin(category);
            }
            else if (category == "Drones")
            {
               categoryId=Helper.GetCategoryIdAdmin(category);
            }
            else if (category == "Nerf")
            {
                categoryId = Helper.GetCategoryIdAdmin(category);
            }
            else if (category == "Boardgames")
            {
                categoryId = Helper.GetCategoryIdAdmin(category);
            }
            else if (category == "Collection items")
            {
                categoryId = Helper.GetCategoryIdAdmin(category);
            }
            else
            {
                Console.WriteLine("Error: produktens kommer liga i okategoriserad");

                categoryId = Helper.GetCategoryId(0);
            }
            Console.WriteLine("Information om produkten: ");
            string description = Console.ReadLine();

            Console.WriteLine("Priset: ");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Produkter i lager: ");
            int inventoryBalance = int.Parse(Console.ReadLine());

            Console.WriteLine("Rekommendera produkten?(true or false): ");
            string input = Console.ReadLine();
            bool recommended;
            bool result = bool.TryParse(input, out recommended);

            if (result)
            {
                Console.WriteLine("du har nu valt: " + recommended);
            }
            else
            {
                Console.WriteLine("du skrev något fel, det kommer vara ej rekommenderad");
                recommended = false;
            }

            Console.WriteLine("Vem är tillverkaren: ");
            string supplier = Console.ReadLine();
            using (var db = new MyDbContext())
            {
                var newProduct = new Product { Name = name, CategoryId = categoryId, Description = description, Price = price, InventoryBalance = inventoryBalance, Recommended = recommended, IsDeleted = false, Supplier = supplier };
                db.Product.Add(newProduct);
                db.SaveChanges();
            }
        }
        public static void AddCategoryInfo()
        {
            Console.WriteLine("Namn: ");
            string name = Console.ReadLine();

            Console.WriteLine("Information of kategorin: ");
            string Description = Console.ReadLine();

            using (var db = new MyDbContext())
            {
                var newcategory = new Category { Name = name, Description = Description, IsDeleted = false };
            }
        }
        public static void AdminAddSelect(int locationinfo)
        {
            if (locationinfo == 1)
            {
                Console.WriteLine("error: " + locationinfo);
                AddProductInfo();
            }
            else if (locationinfo == 2)
            {
                Console.WriteLine("error: " + locationinfo);
                AddCategoryInfo();
            }
            else if (locationinfo == 3)
            {
                Console.WriteLine("error: " + locationinfo);
                AddUserInfo();
            }
            else
            {
                Console.WriteLine("error: " + locationinfo);
            }
        }
    }
}
