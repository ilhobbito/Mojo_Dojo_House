using Mojo_Dojo_House.Classes;

namespace Mojo_Dojo_House.DataInput
{
    public class InputData
    {
        public void DataInfo2()//lägger till data för person i data basen
        {
            using (var myDb = new MyDbContext())
            {
                var person1 = new Person { FirstName = "John", LastName = "Doe", PhoneNumber = "0721234567", Email = "john.doe@example.com", Age = 27, City = "Nyköping", Country = "Sweden", Street = "Hemgårdsvägen", PostCode = "61111"};
                var person2 = new Person { FirstName = "Emma", LastName = "Svensson", PhoneNumber = "0722345678", Email = "emma.svensson@example.com", Age = 34, City = "Göteborg", Country = "Sweden", Street = "Kungsgatan", PostCode = "41119" };
                var person3 = new Person { FirstName = "Lars", LastName = "Johansson", PhoneNumber = "0723456789", Email = "lars.johansson@example.com", Age = 45, City = "Malmö", Country = "Sweden", Street = "Stortorget", PostCode = "21122" };
                var person4 = new Person { FirstName = "Anna", LastName = "Karlsson", PhoneNumber = "0724567890", Email = "anna.karlsson@example.com", Age = 29, City = "Uppsala", Country = "Sweden", Street = "Dragarbrunnsgatan", PostCode = "75320" };
                myDb.AddRange(person1, person2, person3, person4);
                myDb.SaveChanges();
                Console.WriteLine("Person,Card and user Data added");
            }
        }
        public void DataInfo4()//Categories and Products
        {
            using (var myDb = new MyDbContext())
            {
                var category = new Category { Name = "Uncategorised", Description = "unsorted categories", IsDeleted = false };

                var category1 = new Category { Name = "Lego", Description = "A versatile and imaginative construction toy, Lego consists of interlocking plastic bricks and an array of accompanying parts. It inspires creativity and innovation, allowing both children and adults to build complex structures from simple, colorful pieces.", IsDeleted = false};

                var category2 = new Category { Name = "Drones", Description = "Drones are unmanned aerial vehicles, ranging from high-tech gadgets for photography and videography to racing and hobbyist models. They offer a unique perspective from the skies and are increasingly popular for recreational and professional use.", IsDeleted = false };

                var category3 = new Category { Name = "Nerf", Description = "Known for their foam-based weaponry, Nerf products are centered around safe, active play. They include a variety of blasters, sports equipment, and accessories, encouraging fun, competitive, and physically engaging games for all ages.", IsDeleted = false };

                var category4 = new Category { Name = "Board Games", Description = "Board games are tabletop games that typically use pieces moved or placed on a pre-marked board. They come in various themes and complexities, offering strategic, educational, and social experiences for players of all ages.", IsDeleted = false };

                var category5 = new Category { Name = "Collection Items", Description = "This category includes a diverse range of collectible items such as action figures, themed mugs, and soft toys. Each item often holds sentimental value or represents a piece of pop culture, appealing to collectors and fans alike." , IsDeleted = false };

                myDb.AddRange(category,category1, category2, category3, category4, category5);
                myDb.SaveChanges();

                var product1 = new Product { Name = "Lego spaceship", CategoryId = 2, Description = "A Lego Spaceship", Price = 199.99, InventoryBalance = 3, Recommended = false, IsDeleted = false };

                var product2 = new Product { Name = "Lego Castle Set", CategoryId = 2, Description = "An intricate Lego set featuring a medieval castle with detailed interiors. Ideal for creative building.", Price = 249.99, InventoryBalance = 5, Recommended = false, IsDeleted = false };

                var product3 = new Product { Name = "Racing Drone", CategoryId = 3, Description = "A high-speed drone designed for competitive racing. Features advanced aerodynamics and controls.", Price = 299.99, InventoryBalance = 4, Recommended = false, IsDeleted = false };

                var product4 = new Product { Name = "Nerf Elite Blaster", CategoryId = 4, Description = "A popular Nerf blaster with high accuracy and range. Perfect for action-packed games.", Price = 29.99, InventoryBalance = 10, Recommended = false, IsDeleted = false };

                var product5 = new Product { Name = "Strategy Board Game", CategoryId = 5, Description = "A challenging board game that tests strategic thinking and planning. Suitable for ages 12 and up.", Price = 49.99, InventoryBalance = 7, Recommended = true, IsDeleted = false };

                var product6 = new Product { Name = "Superhero Action Figure", CategoryId = 6, Description = "A detailed action figure of a popular superhero. A must-have for collectors.", Price = 19.99, InventoryBalance = 15, Recommended = false, IsDeleted = false };

                var product7 = new Product { Name = "Lego Space Station", CategoryId = 2, Description = "A complex Lego set that lets you build a detailed space station. Encourages imaginative play.", Price = 299.99, InventoryBalance = 2, Recommended = false, IsDeleted = false };

                var product8 = new Product { Name = "Photography Drone", CategoryId = 3, Description = "A drone equipped with a high-resolution camera, perfect for aerial photography enthusiasts.", Price = 499.99, InventoryBalance = 3, Recommended = false, IsDeleted = false };

                var product9 = new Product { Name = "Nerf Mega Blaster", CategoryId = 4, Description = "This Nerf blaster fires mega darts for ultimate battle fun. Ideal for outdoor play.", Price = 34.99, InventoryBalance = 8, Recommended = false, IsDeleted = false };

                var product10 = new Product { Name = "Fantasy Adventure Board Game", CategoryId = 5, Description = "Dive into a fantasy world with this engaging board game. Great for family game nights.", Price = 59.99, InventoryBalance = 6, Recommended = false, IsDeleted = false };

                var product11 = new Product { Name = "Collector's Edition Movie Mug", CategoryId = 6, Description = "A beautifully crafted mug featuring iconic movie imagery. Perfect for collectors and fans.", Price = 14.99, InventoryBalance = 20, Recommended = false, IsDeleted = false };

                var product12 = new Product { Name = "Lego Pirate Ship", CategoryId = 2, Description = "Build a classic pirate ship with this Lego set. Filled with details and fun.", Price = 159.99, InventoryBalance = 4, Recommended = false, IsDeleted = false };

                var product13 = new Product { Name = "Mini Drone", CategoryId = 3, Description = "A compact and agile drone, perfect for indoor flying and beginners.", Price = 49.99, InventoryBalance = 10, Recommended = false, IsDeleted = false };

                var product14 = new Product { Name = "Nerf Zombie Strike", CategoryId = 4, Description = "Survive the zombie apocalypse with this Nerf Zombie Strike blaster.", Price = 39.99, InventoryBalance = 12, Recommended = false, IsDeleted = false };

                var product15 = new Product { Name = "Classic Chess Set", CategoryId = 5, Description = "A traditional chess set with wooden pieces. Timeless and educational.", Price = 29.99, InventoryBalance = 9, Recommended = false, IsDeleted = false };

                var product16 = new Product { Name = "Animated Series Soft Toy", CategoryId = 6, Description = "A soft and cuddly toy from a beloved animated series. Perfect for kids and nostalgic adults.", Price = 24.99, InventoryBalance = 15, Recommended = false, IsDeleted = false };

                var product17 = new Product { Name = "Lego Robotics Kit", CategoryId = 2, Description = "An advanced Lego set for building and programming robots. Educational and fun for tech enthusiasts.", Price = 349.99, InventoryBalance = 3, Recommended = true, IsDeleted = false };

                var product18 = new Product { Name = "Surveillance Drone", CategoryId = 3, Description = "A state-of-the-art drone designed for surveillance with advanced camera capabilities.", Price = 599.99, InventoryBalance = 2, Recommended = false, IsDeleted = false };

                var product19 = new Product { Name = "Nerf Super Soaker", CategoryId = 4, Description = "Beat the heat with this powerful Nerf Super Soaker. Ideal for summer fun.", Price = 19.99, InventoryBalance = 20, Recommended = false, IsDeleted = false };

                var product20 = new Product { Name = "Family Trivia Game", CategoryId = 5, Description = "A fun and educational trivia game for the whole family. Covers a wide range of topics.", Price = 39.99, InventoryBalance = 8, Recommended = false, IsDeleted = false };

                var product21 = new Product { Name = "Vintage Comic Book", CategoryId = 6, Description = "A rare vintage comic book, a prized item for serious collectors and enthusiasts.", Price = 99.99, InventoryBalance = 5, Recommended = false, IsDeleted = false };

                var product22 = new Product { Name = "Lego City Set", CategoryId = 2, Description = "Create your own urban landscape with this detailed Lego City set.", Price = 199.99, InventoryBalance = 6, Recommended = false, IsDeleted = false };

                var product23 = new Product { Name = "Explorer Drone", CategoryId = 3, Description = "An all-terrain drone designed for exploration and adventure in various environments.", Price = 399.99, InventoryBalance = 4, Recommended = false };

                var product24 = new Product { Name = "Nerf Laser Ops", CategoryId = 4, Description = "Experience futuristic battles with Nerf Laser Ops. High-tech and action-packed.", Price = 49.99, InventoryBalance = 7, Recommended = false, IsDeleted = false };

                var product25 = new Product { Name = "Mystery Detective Game", CategoryId = 5, Description = "Solve intriguing mysteries with this detective-themed board game. Great for critical thinking.", Price = 44.99, InventoryBalance = 6, Recommended = false, IsDeleted = false };

                var product26 = new Product { Name = "Sci-Fi Movie Poster", CategoryId = 6, Description = "A high-quality poster of a classic sci-fi movie. A must-have for film buffs and collectors.", Price = 29.99, InventoryBalance = 10, Recommended = false, IsDeleted = false };

                var product27 = new Product { Name = "Lego Superhero Set", CategoryId = 2, Description = "Build your favorite superhero scenes with this exciting Lego set.", Price = 159.99, InventoryBalance = 5, Recommended = false, IsDeleted = false };

                var product28 = new Product { Name = "Aerial Photography Drone", CategoryId = 3, Description = "Capture stunning aerial shots with this specialized photography drone.", Price = 549.99, InventoryBalance = 3, Recommended = false, IsDeleted = false };

                var product29 = new Product { Name = "Nerf Rival Precision", CategoryId = 4, Description = "A high-precision Nerf blaster for competitive Nerf battles.", Price = 59.99, InventoryBalance = 9, Recommended = true, IsDeleted = false };

                var product30 = new Product { Name = "Role-Playing Game Kit", CategoryId = 5, Description = "Embark on epic adventures with this comprehensive role-playing game kit.", Price = 79.99, InventoryBalance = 4, Recommended = false, IsDeleted = false };

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
                var order1 = new Order
                {
                    PersonId = 1,
                    CurrentDate = DateTime.Now,
                    OrderProducts = new List<OrderProduct>
                        {
                            new OrderProduct { ProductId = 2, Quantity = 3 },
                            new OrderProduct { ProductId = 4, Quantity = 1 },
                            new OrderProduct { ProductId = 5, Quantity = 2 }
                        }
                };
                order1.TotalPrice = (from op in order1.OrderProducts
                                     join p in myDb.Product on op.ProductId equals p.Id
                                     select op.Quantity * p.Price).Sum();
                myDb.Order.Add(order1);

                var order2 = new Order
                {
                    PersonId = 2,
                    CurrentDate = DateTime.Now,
                    OrderProducts = new List<OrderProduct>
                        {
                            new OrderProduct { ProductId = 1, Quantity = 2 },
                            new OrderProduct { ProductId = 3, Quantity = 2 },
                            new OrderProduct { ProductId = 7, Quantity = 1 }
                        }
                };
                order2.TotalPrice = (from op in order2.OrderProducts
                                     join p in myDb.Product on op.ProductId equals p.Id
                                     select op.Quantity * p.Price).Sum();
                myDb.Order.Add(order2);

                var order3 = new Order
                {
                    PersonId = 3,
                    CurrentDate = DateTime.Now,
                    OrderProducts = new List<OrderProduct>
                        {
                            new OrderProduct { ProductId = 6, Quantity = 1 },
                            new OrderProduct { ProductId = 8, Quantity = 3 },
                            new OrderProduct { ProductId = 10, Quantity = 2 }
                        }
                };
                order3.TotalPrice = (from op in order3.OrderProducts
                                     join p in myDb.Product on op.ProductId equals p.Id
                                     select op.Quantity * p.Price).Sum();
                myDb.Order.Add(order3);

                var order4 = new Order
                {
                    PersonId = 4,
                    CurrentDate = DateTime.Now,
                    OrderProducts = new List<OrderProduct>
                        {
                            new OrderProduct { ProductId = 15, Quantity = 1 },
                            new OrderProduct { ProductId = 20, Quantity = 1 },
                            new OrderProduct { ProductId = 25, Quantity = 1 }
                        }
                };
                order4.TotalPrice = (from op in order4.OrderProducts
                                     join p in myDb.Product on op.ProductId equals p.Id
                                     select op.Quantity * p.Price).Sum();
                myDb.Order.Add(order4);

                myDb.SaveChanges();
            }
        }
    }
}
