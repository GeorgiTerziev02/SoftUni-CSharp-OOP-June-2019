﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class Runner
    {
        public void Start()
        {

            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Engine engine = CreateEngine(parameters);

                engines.Add(engine);

            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = CreateCar(parameters, engines);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static Car CreateCar(string[] parameters, List<Engine> engines)
        {
            Car car = null;
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.model == engineModel);

            int weight = -1;

            if (parameters.Length == 3)
            {
                bool isWeight = int.TryParse(parameters[2], out weight);

                if (isWeight)
                { car = new Car(model, engine, weight); }
                else
                {
                    string color = parameters[2];
                    car = new Car(model, engine, color);
                }
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                car = new Car(model, engine, int.Parse(parameters[2]), color);
            }
            else
            {
                car = new Car(model, engine);
            }

            return car;

        }

        private static Engine CreateEngine(string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            Engine engine = new Engine(model, power);
            int displacement = -1;

            if (parameters.Length == 3)
            {
                bool isDisplacement = int.TryParse(parameters[2], out displacement);
                if (isDisplacement)
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    string efficiency = parameters[2];
                    engine = new Engine(model, power, efficiency);
                }
            }

            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                displacement = int.Parse(parameters[2]);
                engine = new Engine(model, power, displacement, efficiency);
            }
            else
            {
                engine = new Engine(model, power);
            }

            return engine;
        }
    }

}
