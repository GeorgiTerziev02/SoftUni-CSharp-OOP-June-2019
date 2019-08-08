using System;
using Vehicles.Contracts;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Bus : Vehicle, IBus
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {

        }

        public new void Drive(double distance, string command)
        {
            if (command != "DriveEmpty")
            {
                if (this.FuelQuantity - (this.FuelConsumptionPerKm + 1.4) * distance >= 0)
                {
                    this.FuelQuantity = this.FuelQuantity - (this.FuelConsumptionPerKm + 1.4) * distance;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidFuelException, $"{GetType().Name}"));
                }

                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                base.Drive(distance);
            }
        }

    }
}
