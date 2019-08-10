using StorageMaster.Contracts;
using StorageMaster.Exceptions;
using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private List<Storage> storages;
        private List<Product> products;
        private Vehicle currentVehicle;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        public StorageMaster()
        {
            this.storages = new List<Storage>();
            this.products = new List<Product>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }
        public string AddProduct(string type, double price)
        {
            Product product = (Product)this.productFactory.CreateProduct(type, price);
            this.products.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storages.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var vehicle = this.storages
                .FirstOrDefault(s => s.Name == storageName)
                .GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loaded = 0;
            int allProductsCount = productNames.Count();

            foreach (var productName in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (this.products.FirstOrDefault(p => p.GetType().Name == productName) == null)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.OutOfStockException, productName));
                }

                Product productToAdd = this.products.Last(p => p.GetType().Name == productName);
                this.products.Remove(productToAdd);
                this.currentVehicle.LoadProduct(productToAdd);
                loaded++;
            }

            return $"Loaded {loaded}/{allProductsCount} products into {this.currentVehicle.GetType().Name}";

        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            IStorage sourceStorage = this.storages.FirstOrDefault(s => s.Name == sourceName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidSourceStorageException);
            }

            Storage destination = this.storages.FirstOrDefault(s => s.Name == destinationName);

            if (destination == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDestinationStorageException);
            }

            Vehicle vehicleToSend = (Vehicle)sourceStorage.GetVehicle(sourceGarageSlot);

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destination);

            return $"Sent {vehicleToSend.GetType().Name} to {destination.Name} (slot {destinationGarageSlot})";
        }


        //To Do InvalidStorage
        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(s => s.Name == storageName);

            Vehicle vehicleToSend = (Vehicle)storage.GetVehicle(garageSlot);
            int vehicleProducts = vehicleToSend.Trunk.Count();
            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{vehicleProducts} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storages.First(s => s.Name == storageName);

            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                productsCapacity,
                storage.Capacity,
                string.Join(", ", stockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var storage in this.storages.OrderByDescending(s => s.Products.Sum(p => p.Price)).ToArray())
            {
                sb.AppendLine($"{storage.Name}:");
                var totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
