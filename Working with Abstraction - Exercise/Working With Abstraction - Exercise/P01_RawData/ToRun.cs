using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
     public class ToRun
    {
        public void Run()
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    ?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = this.CreateCar(parameters);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = FindCarsFragile(cars, command);
                PrintCars(fragile);
            }
            else
            {
                List<string> flamable = FindCarsFlamable(cars, command);
                PrintCars(flamable);
            }
        }

        private static void PrintCars(List<string> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private static List<string> FindCarsFlamable(List<Car> cars, string command)
        {
            return cars
                .Where(x => x.Cargo.Type == command && x.Engine.Power > 250)
                .Select(x => x.Model)
                .ToList();
        }

        private static List<string> FindCarsFragile(List<Car> cars, string command)
        {
            return cars
                .Where(x => x.Cargo.Type == command && x.tires.Any(y => y.Pressure < 1))
                .Select(x => x.Model)
                .ToList();
        }
        public Car CreateCar(string[] parameters)
        {
            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            var engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            double tire1Pressure = double.Parse(parameters[5]);
            int tire1Age = int.Parse(parameters[6]);
            double tire2Pressure = double.Parse(parameters[7]);
            int tire2Age = int.Parse(parameters[8]);
            double tire3Pressure = double.Parse(parameters[9]);
            int tire3Age = int.Parse(parameters[10]);
            double tire4Pressure = double.Parse(parameters[11]);
            int tire4Age = int.Parse(parameters[12]);
            var tires = new Tire[] { new Tire(tire1Pressure, tire1Age), new Tire(tire2Pressure, tire2Age), new Tire(tire3Pressure, tire3Age), new Tire(tire4Pressure, tire4Age) };

            Car newCar = new Car(model, engine, cargo, tires);

            return newCar;

        }

    }
}
