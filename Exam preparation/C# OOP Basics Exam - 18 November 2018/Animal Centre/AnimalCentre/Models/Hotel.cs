using AnimalCentre.Exceptions;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnimalCentre.Models
{
    public class Hotel : IHotel
    {
        private int capacity;
        private Dictionary<string, IAnimal> animals;
        public Hotel()
        {
            this.capacity = 10;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get => new ReadOnlyDictionary<string, IAnimal>(this.animals);

        }
        public void Accommodate(IAnimal animal)
        {
            if (animals.Count + 1 > capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacityException);
            }

            if(animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalAlreadyExistException, animal.Name));
            }

            animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if(!animals.ContainsKey(animalName))
            {
                throw new ArgumentException(ExceptionMessages.AnimalDoesNotExistException);
            }

            animals[animalName].Owner = owner;
            animals[animalName].IsAdopt = true;
            animals.Remove(animalName);
        }
    }
}
