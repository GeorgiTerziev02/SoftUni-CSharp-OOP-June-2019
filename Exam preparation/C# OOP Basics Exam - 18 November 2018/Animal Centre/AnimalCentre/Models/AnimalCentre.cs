using AnimalCentre.Exceptions;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models
{
    public class AnimalCentre
    {

        private Hotel hotel;
        private Dictionary<string,List<IAnimal>> procedures;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, List<IAnimal>>();
        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal newAnimal = null;
            switch (type)
            {
                case "Lion":
                    newAnimal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    newAnimal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    newAnimal = new Pig(name, energy, happiness, procedureTime);
                    break;
                case "Cat":
                    newAnimal = new Cat(name, energy, happiness, procedureTime);
                    break;
            }
            hotel.Accommodate(newAnimal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            IsRegistered(name);

            IAnimal animalToChip = hotel.Animals[name];

            IProcedure procedure = new Chip();
            procedure.DoService(animalToChip, procedureTime);

            if(!procedures.ContainsKey("Chip"))
            {
                procedures.Add("Chip", new List<IAnimal>());
            }

            procedures["Chip"].Add(animalToChip);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IsRegistered(name);

            IAnimal animalToVaccinate = hotel.Animals[name];

            IProcedure procedure = new Vaccinate();
            procedure.DoService(animalToVaccinate, procedureTime);

            if(!procedures.ContainsKey("Vaccinate"))
            {
                procedures.Add("Vaccinate", new List<IAnimal>());
            }
            procedures["Vaccinate"].Add(animalToVaccinate);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            IsRegistered(name);

            IAnimal animalToFitness = hotel.Animals[name];

            IProcedure procedure = new Fitness();
            procedure.DoService(animalToFitness, procedureTime);

            if(!procedures.ContainsKey("Fitness"))
            {
                procedures.Add("Fitness", new List<IAnimal>());
            }

            procedures["Fitness"].Add(animalToFitness);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            IsRegistered(name);

            IAnimal animalToPlay = hotel.Animals[name];

            IProcedure procedure = new Play();
            procedure.DoService(animalToPlay, procedureTime);

            if (!procedures.ContainsKey("Play"))
            {
                procedures.Add("Play", new List<IAnimal>());
            }
            procedures["Play"].Add(animalToPlay);


            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            IsRegistered(name);

            IAnimal animalToCare = hotel.Animals[name];

            IProcedure procedure = new DentalCare();
            procedure.DoService(animalToCare, procedureTime);

            if(!procedures.ContainsKey("DentalCare"))
            {
                procedures.Add("DentalCare", new List<IAnimal>());
            }

            procedures["DentalCare"].Add(animalToCare);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            IsRegistered(name);

            IAnimal animalToNailTrim = hotel.Animals[name];

            IProcedure procedure = new NailTrim();
            procedure.DoService(animalToNailTrim, procedureTime);

            if (!procedures.ContainsKey("NailTrim"))
            {
                procedures.Add("NailTrim", new List<IAnimal>());
            }

            procedures["NailTrim"].Add(animalToNailTrim);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            IsRegistered(animalName);

            IAnimal animalToAdopt = hotel.Animals[animalName];

            hotel.Adopt(animalName, owner);

            if (animalToAdopt.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{type}");

            foreach (var animal in procedures[type])
            {
                Type typeOfAnimal = animal.GetType();
                result.AppendLine($"    Animal type: {typeOfAnimal.Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return result.ToString().TrimEnd();
        }

        private void IsRegistered(string animalName)
        {
            if(!hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalDoesNotExistException, animalName));
            }
        }

    }
}
