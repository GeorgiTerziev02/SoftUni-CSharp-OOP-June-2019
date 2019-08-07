﻿namespace P01_RawData
{
    public class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }

        public string Type
        {
            get { return this.cargoType; }
        }
    }
}
