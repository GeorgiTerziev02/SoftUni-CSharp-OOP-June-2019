using System;
using BorderControl.Contracts;
using BorderControl.Models;
using System.Collections.Generic;

namespace BorderControl.Core
{
    public class Engine
    {
        private List<IIdentifiable> ids;
        private List<IBirthable> birthdays;
        Dictionary<string, IBuyer> rebelsAndCitizens = new Dictionary<string, IBuyer>();


        public Engine()
        {
            this.ids = new List<IIdentifiable>();
            this.birthdays = new List<IBirthable>();
            this.rebelsAndCitizens = new Dictionary<string, IBuyer>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if(tokens.Length==4)
                {
                    CreatePerson(tokens);
                }
                else
                {
                    CreateRebel(tokens);
                }

            }

            string command = Console.ReadLine();

            while (command.ToLower()!="end")
            {
                if(rebelsAndCitizens.ContainsKey(command))
                {
                    rebelsAndCitizens[command].BuyFood();
                }

                command = Console.ReadLine();
            }

            int totalFood = 0;

            foreach (var rebelOrCitizen in rebelsAndCitizens)
            {
                totalFood += rebelOrCitizen.Value.Food;
            }

            Console.WriteLine(totalFood);
        }

        private void CreateRebel(string[] tokens)
        {
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string group = tokens[2];

            IBuyer rebel = new Rebel(name, age, group);

            rebelsAndCitizens.Add(name, rebel);
        }

        private void CreatePet(string[] tokens)
        {
            string name = tokens[1];
            string birthDate = tokens[2];

            IBirthable pet = new Pet(name, birthDate);

            birthdays.Add(pet);
        }

        private void CreateRobot(string[] tokens)
        {
            string model = tokens[1];
            string id = tokens[2];
            IIdentifiable robot = new Robot(model, id);

            ids.Add(robot);
        }

        private void CreatePerson(string[] tokens)
        {
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string id = tokens[2];
            string birthDate = tokens[3];

            IBuyer citizen = new Citizen(name, age, id, birthDate);

            rebelsAndCitizens.Add(name,citizen);
        }
    }
}
