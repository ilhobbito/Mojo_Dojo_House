using Mojo_Dojo_House.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojo_Dojo_House.Classes;

namespace Mojo_Dojo_House.DataInput
{
    public class InputData
    {
        public void DataInfo1()//gör addresser först
        {
            using (var myDb = new MyDbContext())
            {
                var address1 = new Address { City = "Stockholm", Street = "fakestreet 12", Country = "Sweden", Zipcode = "611 11" };
                var address2 = new Address { City = "London", Street = "King's Road 45", Country = "UK", Zipcode = "SW3 5XP" };
                var address3 = new Address { City = "New York", Street = "Broadway 789", Country = "USA", Zipcode = "10001" };
                var address4 = new Address { City = "Paris", Street = "Rue de Rivoli 23", Country = "France", Zipcode = "75001" };
                var address5 = new Address { City = "Tokyo", Street = "Shibuya 3-6-20", Country = "Japan", Zipcode = "150-0002" };
                var address6 = new Address { City = "Berlin", Street = "Unter den Linden 17", Country = "Germany", Zipcode = "10117" };
                var address7 = new Address { City = "Sydney", Street = "George Street 102", Country = "Australia", Zipcode = "2000" };
                var address8 = new Address { City = "Rio de Janeiro", Street = "Avenida Atlântica 1234", Country = "Brazil", Zipcode = "22021-000" };
                var address9 = new Address { City = "Toronto", Street = "Queen St W 456", Country = "Canada", Zipcode = "M5V 2A2" };
                var address10 = new Address { City = "Cape Town", Street = "Long Street 789", Country = "South Africa", Zipcode = "8001" };
                var address11 = new Address { City = "Moscow", Street = "Tverskaya Street 22", Country = "Russia", Zipcode = "125009" };
                var address12 = new Address { City = "Paris", Street = "Champs-Élysées 10", Country = "France", Zipcode = "75008" };
                var address13 = new Address { City = "New York", Street = "Wall Street 5", Country = "USA", Zipcode = "10005" };


                myDb.AddRange(address1, address2, address3, address4, address5, address6, address7, address8, address9, address10, address11, address12, address13);
                myDb.SaveChanges();

                Console.WriteLine("Adresses added");
            }
        }
        public void DataInfo2()//lägger till data för person, card och users
        {
            using (var myDb = new MyDbContext())
            {
                var person1 = new Person { FirstName = "John", LastName = "Doe", PhoneNumber = "0721234567", Email = "john.doe@example.com", Age = 27, AddressId = 1 };
                var person2 = new Person { FirstName = "Jane", LastName = "Smith", PhoneNumber = "0701111111", Email = "jane.smith@example.net", Age = 23, AddressId = 2 };
                var person3 = new Person { FirstName = "Alice", LastName = "Brown", PhoneNumber = "0722233445", Email = "alice.brown@example.org", Age = 30, AddressId = 3 };
                var person4 = new Person { FirstName = "Bob", LastName = "Johnson", PhoneNumber = "0733344556", Email = "bob.johnson@example.com", Age = 35, AddressId = 4 };
                var person5 = new Person { FirstName = "Emily", LastName = "Davis", PhoneNumber = "0744455667", Email = "emily.davis@example.net", Age = 29, AddressId = 5 };
                var person6 = new Person { FirstName = "Michael", LastName = "Wilson", PhoneNumber = "0755566778", Email = "michael.wilson@example.org", Age = 32, AddressId = 6 };
                var person7 = new Person { FirstName = "Sarah", LastName = "Miller", PhoneNumber = "0766677889", Email = "sarah.miller@example.com", Age = 24, AddressId = 7 };
                var person8 = new Person { FirstName = "Chris", LastName = "Taylor", PhoneNumber = "0777788990", Email = "chris.taylor@example.net", Age = 28, AddressId = 8 };
                var person9 = new Person { FirstName = "Jessica", LastName = "Anderson", PhoneNumber = "0788899001", Email = "jessica.anderson@example.org", Age = 26, AddressId = 9 };
                var person10 = new Person { FirstName = "David", LastName = "Thomas", PhoneNumber = "0799900112", Email = "david.thomas@example.com", Age = 31, AddressId = 10 };


                var card1 = new Card { CardNumber = "123456789", Person = person1 };
                var card2 = new Card { CardNumber = "987654321", Person = person2 };
                var card3 = new Card { CardNumber = "234567891", Person = person3 };
                var card4 = new Card { CardNumber = "876543219", Person = person4 };
                var card5 = new Card { CardNumber = "345678912", Person = person5 };
                var card6 = new Card { CardNumber = "765432198", Person = person6 };
                var card7 = new Card { CardNumber = "456789123", Person = person7 };
                var card8 = new Card { CardNumber = "654321987", Person = person8 };
                var card9 = new Card { CardNumber = "567891234", Person = person9 };
                var card10 = new Card { CardNumber = "543219876", Person = person10 };

                var user1 = new User { Username = "john_doe", Password = "password123", Person = person1, CardId = 1 };
                var user2 = new User { Username = "jane_smith", Password = "password321", Person = person2, CardId = 2 };
                var user3 = new User { Username = "alice_brown", Password = "pass12345", Person = person3, CardId = 3 };
                var user4 = new User { Username = "bob_johnson", Password = "12345pass", Person = person4, CardId = 4 };
                var user5 = new User { Username = "emily_davis", Password = "emily1234", Person = person5, CardId = 5 };
                var user6 = new User { Username = "michael_wilson", Password = "mike1234", Person = person6, CardId = 6 };
                var user7 = new User { Username = "sarah_miller", Password = "sarahpass", Person = person7, CardId = 7 };
                var user8 = new User { Username = "chris_taylor", Password = "chrispass", Person = person8, CardId = 8 };
                var user9 = new User { Username = "jessica_anderson", Password = "jess1234", Person = person9, CardId = 9 };
                var user10 = new User { Username = "david_thomas", Password = "davidpass", Person = person10, CardId = 10 };


                myDb.AddRange(person1, person2, person3, person4, person5, person6, person7, person8, person9, person10);
                myDb.AddRange(card1, card2, card3, card4, card5, card6, card7, card8, card9, card10);
                myDb.AddRange(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10);


                myDb.SaveChanges();

                Console.WriteLine("Person,Card and user Data added");
            }
        }
        public void DataInfo3()//Supplier
        {
            using (var myDb = new MyDbContext())
            {
                var supplier1 = new Supplier { Name = "Hasbro Inc", AddressId = 11 };
                var supplier2 = new Supplier { Name = "Sony Corporation", AddressId = 12 };
                var supplier3 = new Supplier { Name = "Samsung Electronics", AddressId = 13 };

                myDb.AddRange(supplier1, supplier2, supplier3);
                myDb.SaveChanges();
            }
        }

        public void DataInfo4()//Categories and Products
        {
            using (var myDb = new MyDbContext())
            {
                var category1 = new Category { Name = "Lego", Description = "A versatile and imaginative construction toy, Lego consists of interlocking plastic bricks and an array of accompanying parts. It inspires creativity and innovation, allowing both children and adults to build complex structures from simple, colorful pieces." };

                var category2 = new Category { Name = "Drones", Description = "Drones are unmanned aerial vehicles, ranging from high-tech gadgets for photography and videography to racing and hobbyist models. They offer a unique perspective from the skies and are increasingly popular for recreational and professional use." };

                var category3 = new Category { Name = "Nerf", Description = "Known for their foam-based weaponry, Nerf products are centered around safe, active play. They include a variety of blasters, sports equipment, and accessories, encouraging fun, competitive, and physically engaging games for all ages." };

                var category4 = new Category { Name = "Board Games", Description = "Board games are tabletop games that typically use pieces moved or placed on a pre-marked board. They come in various themes and complexities, offering strategic, educational, and social experiences for players of all ages." };

                var category5 = new Category { Name = "Collection Items", Description = "This category includes a diverse range of collectible items such as action figures, themed mugs, and soft toys. Each item often holds sentimental value or represents a piece of pop culture, appealing to collectors and fans alike." };

                myDb.AddRange(category1, category2, category3, category4, category5);
                myDb.SaveChanges();

                var product1 = new Product { Name = "Lego spaceship", CategoryId = 1, Description = "A Lego Spaceship", Price = 199.99, SupplierId = 1, InventoryBalance = 3, Recommended = false };

                var product2 = new Product { Name = "Lego Castle Set", CategoryId = 1, Description = "An intricate Lego set featuring a medieval castle with detailed interiors. Ideal for creative building.", Price = 249.99, SupplierId = 2, InventoryBalance = 5, Recommended = false };

                var product3 = new Product { Name = "Racing Drone", CategoryId = 2, Description = "A high-speed drone designed for competitive racing. Features advanced aerodynamics and controls.", Price = 299.99, SupplierId = 1, InventoryBalance = 4, Recommended = false };

                var product4 = new Product { Name = "Nerf Elite Blaster", CategoryId = 3, Description = "A popular Nerf blaster with high accuracy and range. Perfect for action-packed games.", Price = 29.99, SupplierId = 3, InventoryBalance = 10, Recommended = false };

                var product5 = new Product { Name = "Strategy Board Game", CategoryId = 4, Description = "A challenging board game that tests strategic thinking and planning. Suitable for ages 12 and up.", Price = 49.99, SupplierId = 2, InventoryBalance = 7, Recommended = true };

                var product6 = new Product { Name = "Superhero Action Figure", CategoryId = 5, Description = "A detailed action figure of a popular superhero. A must-have for collectors.", Price = 19.99, SupplierId = 1, InventoryBalance = 15, Recommended = false };

                var product7 = new Product { Name = "Lego Space Station", CategoryId = 1, Description = "A complex Lego set that lets you build a detailed space station. Encourages imaginative play.", Price = 299.99, SupplierId = 2, InventoryBalance = 2, Recommended = false };

                var product8 = new Product { Name = "Photography Drone", CategoryId = 2, Description = "A drone equipped with a high-resolution camera, perfect for aerial photography enthusiasts.", Price = 499.99, SupplierId = 3, InventoryBalance = 3, Recommended = false };

                var product9 = new Product { Name = "Nerf Mega Blaster", CategoryId = 3, Description = "This Nerf blaster fires mega darts for ultimate battle fun. Ideal for outdoor play.", Price = 34.99, SupplierId = 1, InventoryBalance = 8, Recommended = false };

                var product10 = new Product { Name = "Fantasy Adventure Board Game", CategoryId = 4, Description = "Dive into a fantasy world with this engaging board game. Great for family game nights.", Price = 59.99, SupplierId = 3, InventoryBalance = 6, Recommended = false };

                var product11 = new Product { Name = "Collector's Edition Movie Mug", CategoryId = 5, Description = "A beautifully crafted mug featuring iconic movie imagery. Perfect for collectors and fans.", Price = 14.99, SupplierId = 2, InventoryBalance = 20, Recommended = false };

                var product12 = new Product { Name = "Lego Pirate Ship", CategoryId = 1, Description = "Build a classic pirate ship with this Lego set. Filled with details and fun.", Price = 159.99, SupplierId = 3, InventoryBalance = 4, Recommended = false };

                var product13 = new Product { Name = "Mini Drone", CategoryId = 2, Description = "A compact and agile drone, perfect for indoor flying and beginners.", Price = 49.99, SupplierId = 1, InventoryBalance = 10, Recommended = false };

                var product14 = new Product { Name = "Nerf Zombie Strike", CategoryId = 3, Description = "Survive the zombie apocalypse with this Nerf Zombie Strike blaster.", Price = 39.99, SupplierId = 2, InventoryBalance = 12, Recommended = false };

                var product15 = new Product { Name = "Classic Chess Set", CategoryId = 4, Description = "A traditional chess set with wooden pieces. Timeless and educational.", Price = 29.99, SupplierId = 3, InventoryBalance = 9, Recommended = false };

                var product16 = new Product { Name = "Animated Series Soft Toy", CategoryId = 5, Description = "A soft and cuddly toy from a beloved animated series. Perfect for kids and nostalgic adults.", Price = 24.99, SupplierId = 1, InventoryBalance = 15, Recommended = false };

                var product17 = new Product { Name = "Lego Robotics Kit", CategoryId = 1, Description = "An advanced Lego set for building and programming robots. Educational and fun for tech enthusiasts.", Price = 349.99, SupplierId = 2, InventoryBalance = 3, Recommended = true };

                var product18 = new Product { Name = "Surveillance Drone", CategoryId = 2, Description = "A state-of-the-art drone designed for surveillance with advanced camera capabilities.", Price = 599.99, SupplierId = 3, InventoryBalance = 2, Recommended = false };

                var product19 = new Product { Name = "Nerf Super Soaker", CategoryId = 3, Description = "Beat the heat with this powerful Nerf Super Soaker. Ideal for summer fun.", Price = 19.99, SupplierId = 1, InventoryBalance = 20, Recommended = false };

                var product20 = new Product { Name = "Family Trivia Game", CategoryId = 4, Description = "A fun and educational trivia game for the whole family. Covers a wide range of topics.", Price = 39.99, SupplierId = 2, InventoryBalance = 8, Recommended = false };

                var product21 = new Product { Name = "Vintage Comic Book", CategoryId = 5, Description = "A rare vintage comic book, a prized item for serious collectors and enthusiasts.", Price = 99.99, SupplierId = 3, InventoryBalance = 5, Recommended = false };

                var product22 = new Product { Name = "Lego City Set", CategoryId = 1, Description = "Create your own urban landscape with this detailed Lego City set.", Price = 199.99, SupplierId = 1, InventoryBalance = 6, Recommended = false };

                var product23 = new Product { Name = "Explorer Drone", CategoryId = 2, Description = "An all-terrain drone designed for exploration and adventure in various environments.", Price = 399.99, SupplierId = 2, InventoryBalance = 4, Recommended = false };

                var product24 = new Product { Name = "Nerf Laser Ops", CategoryId = 3, Description = "Experience futuristic battles with Nerf Laser Ops. High-tech and action-packed.", Price = 49.99, SupplierId = 3, InventoryBalance = 7, Recommended = false };

                var product25 = new Product { Name = "Mystery Detective Game", CategoryId = 4, Description = "Solve intriguing mysteries with this detective-themed board game. Great for critical thinking.", Price = 44.99, SupplierId = 1, InventoryBalance = 6, Recommended = false };

                var product26 = new Product { Name = "Sci-Fi Movie Poster", CategoryId = 5, Description = "A high-quality poster of a classic sci-fi movie. A must-have for film buffs and collectors.", Price = 29.99, SupplierId = 2, InventoryBalance = 10, Recommended = false };

                var product27 = new Product { Name = "Lego Superhero Set", CategoryId = 1, Description = "Build your favorite superhero scenes with this exciting Lego set.", Price = 159.99, SupplierId = 3, InventoryBalance = 5, Recommended = false };

                var product28 = new Product { Name = "Aerial Photography Drone", CategoryId = 2, Description = "Capture stunning aerial shots with this specialized photography drone.", Price = 549.99, SupplierId = 1, InventoryBalance = 3, Recommended = false };

                var product29 = new Product { Name = "Nerf Rival Precision", CategoryId = 3, Description = "A high-precision Nerf blaster for competitive Nerf battles.", Price = 59.99, SupplierId = 2, InventoryBalance = 9, Recommended = true };

                var product30 = new Product { Name = "Role-Playing Game Kit", CategoryId = 4, Description = "Embark on epic adventures with this comprehensive role-playing game kit.", Price = 79.99, SupplierId = 3, InventoryBalance = 4, Recommended = false };
                myDb.AddRange(
                product1, product2, product3, product4, product5,
                product6, product7, product8, product9, product10,
                product11, product12, product13, product14, product15,
                product16, product17, product18, product19, product20,
                product21, product22, product23, product24, product25,
                product26, product27, product28, product29, product30);

                myDb.SaveChanges();
            }
        }

        public void DataInfo5()//Orders
        {
            using (var myDb = new MyDbContext())
            {
                var orderDetails1 = new List<OrderDetail>();
                var productIds1 = new int[] { 2, 4, 5 };
                var quantities1 = new int[] { 3, 1, 2 };
                double totalPrice1 = Helpers.Helper.CalculateOrderTotal(myDb, productIds1, quantities1, orderDetails1);
                Helpers.Helper.CreateAndSaveOrder(myDb, 4, totalPrice1, orderDetails1);

                var orderDetails2 = new List<OrderDetail>();
                var productIds2 = new int[] { 1, 3, 7 };
                var quantities2 = new int[] { 2, 2, 1 };
                double totalPrice2 = Helpers.Helper.CalculateOrderTotal(myDb, productIds2, quantities2, orderDetails2);
                Helpers.Helper.CreateAndSaveOrder(myDb, 1, totalPrice2, orderDetails2);

                var orderDetails3 = new List<OrderDetail>();
                var productIds3 = new int[] { 6, 8, 10 };
                var quantities3 = new int[] { 1, 3, 2 };
                double totalPrice3 = Helpers.Helper.CalculateOrderTotal(myDb, productIds3, quantities3, orderDetails3);
                Helpers.Helper.CreateAndSaveOrder(myDb, 2, totalPrice3, orderDetails3);

                var orderDetails4 = new List<OrderDetail>();
                var productIds4 = new int[] { 15, 20, 25 };
                var quantities4 = new int[] { 1, 1, 1 };
                double totalPrice4 = Helpers.Helper.CalculateOrderTotal(myDb, productIds4, quantities4, orderDetails4);
                Helpers.Helper.CreateAndSaveOrder(myDb, 3, totalPrice4, orderDetails4);
            }
        }
    }
}
