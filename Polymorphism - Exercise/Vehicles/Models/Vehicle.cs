using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.TankCapacity = tankCapacity;
            CheckCapacity();
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumptionPerKm
        {
            get
            {
                return this.fuelConsumptionPerKm;
            }
            protected set
            {

                this.fuelConsumptionPerKm = value;
            }
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            private set
            {
                this.tankCapacity = value;
            }
        }

        private void CheckCapacity()
        {
            if (this.FuelQuantity > TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }

        public virtual void Drive(double distance)
        {
            if (this.FuelQuantity - this.FuelConsumptionPerKm * distance >= 0)
            {
                this.FuelQuantity = this.FuelQuantity - this.FuelConsumptionPerKm * distance;
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidFuelException, $"{GetType().Name}"));
            }

            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double fuel)
        {
            if(fuel<=0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeFuelException);
            }

            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRefuelException, fuel));
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
