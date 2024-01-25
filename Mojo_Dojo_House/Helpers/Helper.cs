using Microsoft.Data.SqlClient;
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
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;


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
        public static void CallQueries()
        {
            Console.WriteLine("Välj mellan 1-3");
            Console.WriteLine("1: Produkter sorterade efter leverantör");
            Console.WriteLine("2: Sortera efter bästsäljande");
            Console.WriteLine("3: Presenter under 100kr");
            var key1 = Console.ReadKey();
            Console.Clear();
            switch (key1.KeyChar)
            {
                case '1':
                    using (var db = new MyDbContext())
                    {
                        var sortSupplier = db.Product.OrderBy(p => p.Supplier).ToList();
                        Console.WriteLine("Produkter sorterade efter leverantör: ");
                        foreach (var product in sortSupplier)
                        {
                            Console.WriteLine($"ProduktId: {product.Id}, Namn: {product.Name}, Supplier: {product.Supplier}");
                        }
                    }
                    Thread.Sleep(100);
                    break;
                case '2':
                    using (var db = new MyDbContext())
                    {

                        var orderHistory = new List<string>();
                        var ordersProduct = db.OrderProduct;
                        var products = db.Product;

                        var bestSeller = (from o in ordersProduct
                                          join p in products on o.ProductId equals p.Id
                                          select new
                                          {
                                              p.Name,
                                              o.Quantity
                                          }).OrderByDescending(o => o.Quantity);

                        Console.WriteLine("Bästsäljande produkter");
                        foreach (var O in bestSeller)
                        {
                            Console.WriteLine($"Namn: {O.Name}           Sålda produkter: {O.Quantity}");
                        }
                    }
                    break;
                case '3':
                    using (var db = new MyDbContext())
                    {
                        var cheapPresents = db.Product.Where(p => p.Price < 100).ToList();

                        foreach (var present in cheapPresents)
                        {
                            Console.WriteLine(present.Name);
                        }
                    }
                    break;
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

        public static string GetProductPrice(int categoryId, int keyPress)
        {
            int i = keyPress;
            var Product = new List<string>();
            using (var db = new MyDbContext())
            {
                var products = db.Product.Where(c => c.CategoryId == categoryId).ToList();
                foreach (var product in products)
                {
                    Product.Add("" + product.Price);
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
        public static void DeleteShoppingCart(int Id)
        {
            using (var db = new MyDbContext())
            {
                var shoppingCart = db.ShoppingCarts.FirstOrDefault(s => s.Id == Id);

                db.ShoppingCarts.Remove(shoppingCart);

                db.SaveChanges();
            }
        }

        public static void ChangeShoppingCartQuantity(int Id, int quantity)
        {
            using (var db = new MyDbContext())
            {
                var shoppingCart = db.ShoppingCarts.FirstOrDefault(s => s.Id == Id);
                
                shoppingCart.Quantity = quantity;

                db.SaveChanges();
            }
        }

        public static List<string> GetShoppingCart()
        {
            var Product = new List<string>();
            using (var db = new MyDbContext())
            {
                  var ShoppingCart = db.ShoppingCarts.Include(s => s.Product).Where(s => s.Id != null).ToList();


                  foreach (var product in ShoppingCart)
                {
                    Product.Add("Id: " + product.Id + " Namn: " + product.Product.Name + " Antal: " + product.Quantity + " Pris:" + product.TotalPrice);
                }

                if (Product .Count > 0)
                {
                    return Product;
                }
                else
                {
                    Product.Add("Tom varukorg");
                    return Product;
                }
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
        public static void SaveShoppingCartToOrder(int personId)
        {
            using ( var db = new MyDbContext())
            {
                var products = new List<int>();
                var shoppingcart = db.ShoppingCarts.Where(s => s.Id != null).ToList();
                var orderProducts = new List<OrderProduct>();
                foreach ( var item in shoppingcart)
                {
                    orderProducts.Add(new OrderProduct { ProductId = item.productId, Quantity = item.Quantity });
                }
                var order1 = new Order
                {
                    PersonId = personId,
                    CurrentDate = DateTime.Now,
                    OrderProducts = orderProducts
                };
                order1.TotalPrice = (from op in order1.OrderProducts
                                     join p in db.Product on op.ProductId equals p.Id
                                     select op.Quantity * p.Price).Sum();
                db.Order.Add(order1);
                db.SaveChanges();
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
                    Console.WriteLine("Går ej");
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

                if (Recommend .Count > 0)
                {

                }
                else
                {
                    Recommend.Add("Finns inga rekommenderade produkter");
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
        public static void DeleteCart()
        {
            using (var db = new MyDbContext())
            {

                var product = db.ShoppingCarts.Where(s => s.Id != null);

                foreach (var item in product)
                {
                    db.ShoppingCarts.Remove(item);
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

                if (i < categories.Count)
                {
                    int Number = categories[i].Id;
                    return Number;
                }
                else
                {
                    return 0;
                }

            }
        }
        public static int GetUnsortedItems()
        {
                using (var db = new MyDbContext())
                {
                var unsortedProductCount = db.Product.Count(p => p.CategoryId == 1 && p.Category.Name == "Uncategorised");
                return unsortedProductCount;
            }
        }


        public static int SetCategoryMiss()
        {
            var i = 0;
            using (var db = new MyDbContext())
            {
                var category = new List<int>();
                var categories = db.Category
                                   .Where(c => c.Id != null)
                                   .OrderBy(c => c.Id)
                                   .ToList();

                if (i < categories.Count)
                {
                    int Number = categories[0].Id;
                    return Number;
                }
                else
                {
                    return 0;
                }

            }
        }
        public static List<string> GetOrderHistory()
        {
            var i = 0;
            using (var db = new MyDbContext())
            {
                var orderHistory = new List<string>();
                var orders = db.Order;
                var person = db.Person;

                var returnValue = (from o in orders
                                   join p in person on o.PersonId equals p.Id
                                   select new
                                   {
                                       p.FirstName,
                                       p.LastName,
                                       o.TotalPrice,
                                       o.CurrentDate
                                   }); ;
                foreach (var O in returnValue)
                {

                    var orderDetails = $"Person:{O.FirstName} {O.LastName}, Priset: {O.TotalPrice}, Datum: {O.CurrentDate}";
                    orderHistory.Add(orderDetails);
                }
                return orderHistory;
            }
        }
        public static int GetCategoryIdAdmin(string categori)
        {
            using (var db = new MyDbContext())
            {
                var category = new List<int>();
                var categories = from c in db.Category
                                 where c.Name == categori
                                 orderby c.Id
                                 select c;
                categories.ToList();

                foreach (var c in categories)
                {
                    category.Add(c.Id);
                }

                int Number = category[0];
                return Number;
            }
        }

        public static int AddUserInfo()
        {

            Console.WriteLine("Stad: ");
            string city = Console.ReadLine();
                             
            Console.WriteLine("Gata: ");
            string street = Console.ReadLine();

            Console.WriteLine("Land: ");
            string country = Console.ReadLine();

            Console.WriteLine("Postkod: ");
            string postcode = Console.ReadLine();

            Console.WriteLine("Förnamn: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Efternamn: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Telefonnummer: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Age: ");
            int age = int.Parse(Console.ReadLine());



            using (var db = new MyDbContext())
            {
                
                var newPerson = new Person { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email, Age = age, City = city, Country = country, Street = street, PostCode = postcode};

                db.Person.Add(newPerson);
                db.SaveChanges();

                return newPerson.Id;
            }
        }

        public static void AddProductInfo()
        {
            int categoryId = 0;
            Console.WriteLine("Namn: ");
            string name = Console.ReadLine();

            Console.WriteLine("ategori: ");
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
                Console.WriteLine("Error: produkten kommer ligga i okategoriserad");

                categoryId = SetCategoryMiss();
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
                Console.WriteLine("Du har nu valt: " + recommended);
            }
            else
            {
                Console.WriteLine("Du skrev något fel eller false");
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

            Console.WriteLine("Information om kategorin: ");
            string Description = Console.ReadLine();

            using (var db = new MyDbContext())
            {
                var newcategory = new Category { Name = name, Description = Description, IsDeleted = false };
                db.Category.Add(newcategory);
                db.SaveChanges();
            }
        }

        public static void ChangeProductInfo()
        {
            Console.WriteLine("Vilken produkt vill du ändra?(Id): ");
            Draw.AdminProducts();
            int productId = int.Parse(Console.ReadLine());

            Console.WriteLine("Vad vill du ändra?: ");
            Console.WriteLine("Name(string), CategoryId(int), Description(string), Price(double), Inventorybalance(int),Supplier(string), Recommended(bool), Isdeleted(bool)");
            string RowInfo = Console.ReadLine();
            RowInfo = char.ToUpper(RowInfo[0]) + RowInfo[1..].ToLower();

            Console.WriteLine("Vad vill du ändra det till?: ");
            string ChangeInfo = Console.ReadLine();

            ChangeProduct(RowInfo, productId, ChangeInfo);


        }
        public static void ChangeProduct(string rowInfo, int id, string changeInfo)
        {
            using (var db = new MyDbContext())
            {
                var product = db.Product.FirstOrDefault(item  => item.Id == id);

                if (rowInfo == "Name")
                {
                    product.Name = changeInfo;
                }
                else if (rowInfo == "Description")
                {
                    product.Description = changeInfo;
                }
                else if (rowInfo == "Supplier")
                {
                    product.Supplier = changeInfo;
                }
                else if (rowInfo == "Inventorybalance")
                {
                    product.InventoryBalance = int.Parse(changeInfo);
                }
                else if (rowInfo == "Categoryid")
                {
                    product.CategoryId = int.Parse(changeInfo);
                }
                else if (rowInfo == "Price")
                {
                    product.Price = double.Parse(changeInfo);
                }
                else if (rowInfo == "Isdeleted")
                {
                    product.IsDeleted = bool.Parse(changeInfo);
                }
                else if (rowInfo == "Recommended")
                {
                    product.Recommended = bool.Parse(changeInfo);
                }
                else
                {
                    Console.WriteLine("error error error");
                }
                db.SaveChanges();
            }
        }
        public static void ChangeCategoryInfo()
        {
            Console.WriteLine("Vilken kategori vill du ändra?(Id): ");
            Draw.AdminCategories();
            int categoryId = int.Parse(Console.ReadLine());

            Console.WriteLine("Vad vill du ändra?: ");
            Console.WriteLine("Name(string), Description(string), Isdeleted(bool)");
            string RowInfo = Console.ReadLine();
            RowInfo = char.ToUpper(RowInfo[0]) + RowInfo[1..].ToLower();

            Console.WriteLine("Vad vill du ändra det till?: ");
            string ChangeInfo = Console.ReadLine();

            Changecategory(RowInfo, categoryId, ChangeInfo);
        }
        public static void Changecategory(string rowInfo, int id, string changeInfo)
        {
            using (var db = new MyDbContext())
            {
                var Category = db.Category.FirstOrDefault(item => item.Id == id);

                if (rowInfo == "Name")
                {
                    Category.Name = changeInfo;
                }
                else if (rowInfo == "Description")
                {
                    Category.Description = changeInfo;
                }
                else if (rowInfo == "Isdeleted")
                {
                    Category.IsDeleted = bool.Parse(changeInfo);
                }
                else
                {
                    Console.WriteLine("error error");
                }
                db.SaveChanges();
            }
        }

        public static void ChangePersonInfo()
        {
            Console.WriteLine("Vilken Person vill du ändra?(Id): ");
            Draw.AdminUsers();
            int personId = int.Parse(Console.ReadLine());

            Console.WriteLine("Vad vill du ändra?: ");
            Console.WriteLine("FirstName(string), LastName(string), Phonenumber(string), Email(string), Age(int), city(string), Country(string), Street(string), PostCode(int)");
            string RowInfo = Console.ReadLine();
            RowInfo = char.ToUpper(RowInfo[0]) + RowInfo[1..].ToLower();

            Console.WriteLine("Vad vill du ändra det till?: ");
            string ChangeInfo = Console.ReadLine();

            ChangePerson(RowInfo, personId, ChangeInfo);
        }

        public static void ChangePerson(string rowInfo, int id, string changeInfo)
        {
            using (var db = new MyDbContext())
            {
                var person = db.Person.FirstOrDefault(item => item.Id == id);

                if (rowInfo == "Förnamn")
                {
                    person.FirstName = changeInfo;
                }
                else if (rowInfo == "Efternamn")
                {
                    person.LastName = changeInfo;
                }
                else if (rowInfo == "Telefonnummer")
                {
                    person.PhoneNumber = changeInfo;
                }
                else if (rowInfo == "Email")
                {
                    person.Email = changeInfo;
                }
                else if (rowInfo == "Ålder")
                {
                    person.Age = int.Parse(changeInfo);
                }
                else if (rowInfo == "Stad")
                {
                    person.City = changeInfo;
                }
                else if (rowInfo == "Gata")
                {
                    person.Street = changeInfo;
                }
                else if (rowInfo == "Borttagen")
                {
                    person.IsDeleted = bool.Parse(changeInfo);
                }
                else if (rowInfo == "Postnummer")
                {
                    person.PostCode = changeInfo;
                }
                else
                {
                    Console.WriteLine("error");
                }
                db.SaveChanges();
            }
        }

        public static void DeleteProductInfo()
        {
            Console.WriteLine("Vilken produkt vill du ta bort?(id): ");
            Draw.AdminProducts();
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine($"Nu är Id: {id} borttagen");

            DeleteProduct(id);

        }
        public static void DeleteProduct(int id)
        {
            using (var db = new MyDbContext())
            {
                int i = 0;
                var product = db.Product.FirstOrDefault(item => item.Id == id);
                if (product != null)
                {
                    product.IsDeleted = true;
                }
                else
                {
                }
                db.SaveChanges();
            }
        }
        public static void DeleteCategoryInfo()
        {
            Console.WriteLine("Vilken kategori vill du ta bort?(id): ");
            Draw.AdminCategories();
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine($"Nu är Id: {id} borttagen");

            DeleteCategory(id);

        }
        public static void DeleteCategory(int id)
        {
            using (var db = new MyDbContext())
            {
                int i = 0;
                var Category = db.Category.FirstOrDefault(item => item.Id == id);
                if(Category != null)
                {
                    Category.IsDeleted = true;
                }
                else
                {

                }
                db.SaveChanges();

            }
        }
        public static void DeletePersonInfo()
        {
            Console.WriteLine("Vilken Person vill du ta bort?(id): ");
            Draw.AdminUsers();
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine($"Nu är Id: {id} borttagen");

            DeletePerson(id);

        }
        public static void DeletePerson(int id)
        {
            using (var db = new MyDbContext())
            {
                int i = 0;
                var Person = db.Person.FirstOrDefault(item => item.Id == id);
                if (Person != null)
                {
                    Person.IsDeleted = true;
                }
                else
                {
                }
                db.SaveChanges();
            }
        }
        public static void AdminAddSelect(int locationinfo)
        {
            if (locationinfo == 1)
            {
                Console.WriteLine("Du har nu börjat lägga till en produkt: ");
                AddProductInfo();
            }
            else if (locationinfo == 2)
            {
                Console.WriteLine("Du har nu börjat lägga till en kategori: ");
                AddCategoryInfo();
            }
            else if (locationinfo == 3)
            {
                Console.WriteLine("Du har nu börjat lägga till en användare: ");
                AddUserInfo();
            }
            else
            {
                Console.WriteLine("error: " + locationinfo);
            }
        }

        public static void AdminChangeSelect(int locationinfo)
        {
            if (locationinfo == 1)
            {
                Console.WriteLine("Du har nu börjat ändra en produkt: ");
                ChangeProductInfo();
            }
            else if (locationinfo == 2)
            {
                Console.WriteLine("Du har nu börjat ändra en kategori: ");
                ChangeCategoryInfo();
            }
            else if (locationinfo == 3)
            {
                Console.WriteLine("Du har nu börjat ändra en användare: ");
                ChangePersonInfo();
            }
            else
            {
                Console.WriteLine("error: " + locationinfo);
            }
        }

        public static void AdminDeleteSelect(int  locationinfo)
        {
            if (locationinfo == 1)
            {
                Console.WriteLine("Du har nu börjat ta bort en produkt: ");
                DeleteProductInfo();
            }
            else if (locationinfo == 2)
            {
                Console.WriteLine("Du har nu börjat ta bort en kategori: ");
                DeleteCategoryInfo();
            }
            else if (locationinfo == 3)
            {
                Console.WriteLine("Du har nu börjat ta bort en användare: ");
                DeletePersonInfo();
            }
            else
            {
                Console.WriteLine("error: " + locationinfo + "finns ej");
            }
        }
    }
}
