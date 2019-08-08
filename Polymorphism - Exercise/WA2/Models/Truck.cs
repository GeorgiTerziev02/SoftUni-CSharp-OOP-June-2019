﻿using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double airConditioner = 1.6;
        private const double waster = 0.05;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm+ airConditioner, tankCapacity)
        {

        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            this.FuelQuantity -= fuel * waster;
        }
    }
}
