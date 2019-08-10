using StorageMaster.Contracts;
using StorageMaster.Exceptions;
using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private readonly List<Product> trunk;

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk => this.trunk;

        public bool IsFull => CalculateIfItIsFull();

        public bool IsEmpty => CheckIfTrunkIsEmpty();

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(ExceptionMessages.VehicleIsFullException);
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (!this.trunk.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.VehicleIsEmptyException);
            }

            Product productToReturn = this.trunk.Last();
            this.trunk.RemoveAt(this.trunk.Count - 1);

            return productToReturn;
        }

        private bool CheckIfTrunkIsEmpty()
        {
            return this.Trunk.Count == 0;
        }

        private bool CalculateIfItIsFull()
        {
            double total = 0;

            foreach (var item in this.Trunk)
            {
                total += item.Weight;
            }

            return total >= this.Capacity;
        }

    }
}
