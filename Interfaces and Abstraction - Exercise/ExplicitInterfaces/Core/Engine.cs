using System;
using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string person = Console.ReadLine();

            while (person.ToLower() != "end")
            {
                var tokens = person.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson citizen = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(citizen.GetName());
                Console.WriteLine(resident.GetName());

                person = Console.ReadLine();
            }
        }
    }
}
