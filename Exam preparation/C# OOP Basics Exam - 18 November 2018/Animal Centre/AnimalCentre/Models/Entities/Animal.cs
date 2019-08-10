using System;
using AnimalCentre.Exceptions;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models
{
    public abstract class Animal : IAnimal
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;

        private int happiness;
        private int energy;
        public Animal(string name, int energy, int happiness, int proceduredTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = proceduredTime;
            this.Owner = "Centre";
            this.IsChipped = false;
            this.IsAdopt = false;
            this.IsVaccinated = false;
        }
        public string Name { get; private set; }

        public int Happiness
        {
            get { return this.happiness; }
            set
            {
                if (value < MIN_VALUE || value > MAX_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappinessException);
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < MIN_VALUE || value > MAX_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergyException);
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public virtual string Owner { get; set; }

        public virtual bool IsAdopt { get; set; }

        public virtual bool IsChipped { get; set; }

        public virtual bool IsVaccinated { get; set; }

        public override string ToString()
        {
            return "    Animal type: {0} - {1} - Happiness: {2} - Energy: {3}";
        }

    }
}
