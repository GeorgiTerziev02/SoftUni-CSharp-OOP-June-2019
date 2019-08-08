using System;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            var carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var busInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double carFuel = double.Parse(carInput[1]);
            double carFuelConsumption = double.Parse(carInput[2]);
            double carTankCapacity = double.Parse(carInput[3]);
            Car car = new Car(carFuel, carFuelConsumption, carTankCapacity);

            double truckFuel = double.Parse(truckInput[1]);
            double truckFuelConsumption = double.Parse(truckInput[2]);
            double truckTankCapacity = double.Parse(truckInput[3]);
            Truck truck = new Truck(truckFuel, truckFuelConsumption, truckTankCapacity);

            double busFuel = double.Parse(busInput[1]);
            double busFuelConsumption = double.Parse(busInput[2]);
            double busTankCapacity = double.Parse(busInput[3]);
            Bus bus = new Bus(busFuel, busFuelConsumption, busTankCapacity);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var currentLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = currentLine[0];

                string vehicle = currentLine[1];
                try
                {
                    if (command == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            car.Drive(double.Parse(currentLine[2]));
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Drive(double.Parse(currentLine[2]));
                        }
                        else if(vehicle=="Bus")
                        {
                            bus.Drive(double.Parse(currentLine[2]));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(double.Parse(currentLine[2]));
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(double.Parse(currentLine[2]));
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(double.Parse(currentLine[2]));
                        }
                    }
                    else
                    {
                        bus.DriveEmpty(double.Parse(currentLine[2]));
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

    }
}
