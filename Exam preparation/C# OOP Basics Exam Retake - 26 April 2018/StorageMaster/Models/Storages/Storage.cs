using StorageMaster.Contracts;
using StorageMaster.Exceptions;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage : IStorage
    {
        private readonly List<Product> products;
        private Vehicle[] garage;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new Vehicle[garageSlots];
            this.products = new List<Product>();

            this.InitializeGarage(vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull => CalculateIfIsFull();

        public IReadOnlyCollection<Product> Products => this.products;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGarageSlotIndexException);
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyGarageSlotException);
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicleToSend = GetVehicle(garageSlot);

            deliveryLocation.CheckIfStorageHasFreeSlot();

            int result = deliveryLocation.AddVehilce(vehicleToSend);

            for (int i = 0; i < this.GarageSlots; i++)
            {
                if (this.garage[i] == vehicleToSend)
                {
                    this.garage[i] = null;
                }
            }

            return result;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(ExceptionMessages.StorageIsFullException);
            }

            Vehicle vehicleToUnload = GetVehicle(garageSlot);

            int count = 0;

            while (vehicleToUnload.IsEmpty == false && this.IsFull == false)
            {
                Product newProduct = vehicleToUnload.Unload();
                this.products.Add(newProduct);
                count++;
            }

            return count;
        }

        private bool CalculateIfIsFull()
        {
            double total = 0;

            foreach (var product in this.products)
            {
                total += product.Weight;
            }

            return total >= this.Capacity;
        }

        private bool CheckIfStorageHasFreeSlot()
        {
            foreach (var slot in this.garage)
            {
                if (slot == null)
                {
                    return true;
                }
            }

            throw new InvalidOperationException(ExceptionMessages.NoEmptySlotException);

        }

        private int AddVehilce(Vehicle vehicle)
        {
            int index = Array.IndexOf(this.garage, null);
            this.garage[index] = vehicle;
            //for (int i = 0; i < this.GarageSlots; i++)
            //{
            //    if (this.garage[i] == null)
            //    {
            //        this.garage[i] = vehicle;
            //        index = i;
            //        break;
            //    }
            //}

            return index;
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var garageSlot = 0;
            foreach (var vehicle in vehicles)
            {
                this.garage[garageSlot++] = vehicle;
            }
        }
    }
}
