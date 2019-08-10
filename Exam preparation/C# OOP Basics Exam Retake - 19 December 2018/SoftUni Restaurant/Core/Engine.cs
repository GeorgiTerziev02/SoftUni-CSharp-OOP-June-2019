using System;
using System.Linq;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController restaurant;
        public Engine()
        {
            this.restaurant = new RestaurantController();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] args = command.Split(" ").ToArray();

                string currentCommand = args[0];

                try
                {
                    switch (currentCommand)
                    {
                        case "AddFood":
                            {
                                string type = args[1];
                                string name = args[2];
                                decimal price = decimal.Parse(args[3]);

                                Console.WriteLine(this.restaurant.AddFood(type, name, price));
                            };
                            break;

                        case "AddDrink":
                            {
                                string type = args[1];
                                string name = args[2];
                                int size = int.Parse(args[3]);
                                string brand = args[4];

                                Console.WriteLine(this.restaurant.AddDrink(type, name, size, brand));
                            };
                            break;
                        case "AddTable":
                            {
                                string type = args[1];
                                int tableNumber = int.Parse(args[2]);
                                int capacity = int.Parse(args[3]);

                                Console.WriteLine(this.restaurant.AddTable(type, tableNumber, capacity));
                            };
                            break;
                        case "ReserveTable":
                            {
                                int numberOfPeople = int.Parse(args[1]);

                                Console.WriteLine(this.restaurant.ReserveTable(numberOfPeople));
                            };
                            break;
                        case "OrderFood":
                            {
                                int tableNumber = int.Parse(args[1]);
                                string foodName = args[2];

                                Console.WriteLine(this.restaurant.OrderFood(tableNumber, foodName));
                            };
                            break;
                        case "OrderDrink":
                            {
                                int tableNumber = int.Parse(args[1]);
                                string drinkName = args[2];
                                string drinkBrand = args[3];

                                Console.WriteLine(this.restaurant.OrderDrink(tableNumber, drinkName, drinkBrand));
                            };
                            break;
                        case "LeaveTable":
                            {
                                int tableNumber = int.Parse(args[1]);

                                Console.WriteLine(this.restaurant.LeaveTable(tableNumber));
                            };
                            break;
                        case "GetFreeTablesInfo":
                            {
                                Console.WriteLine(restaurant.GetFreeTablesInfo());
                            };
                            break;
                        case "GetOccupiedTablesInfo":
                            {
                                Console.WriteLine(restaurant.GetOccupiedTablesInfo());
                            };
                            break;

                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(restaurant.GetSummary());
        }
    }
}
