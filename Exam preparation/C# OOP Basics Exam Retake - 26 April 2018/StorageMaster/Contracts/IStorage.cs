﻿using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Contracts
{
    public interface IStorage
    {
        string Name { get;}

        int Capacity { get;}

        int GarageSlots { get; }

        bool IsFull { get; }

        IReadOnlyCollection<Product> Products { get; }

        IReadOnlyCollection<Vehicle> Garage { get; }

        Vehicle GetVehicle(int garageSlot);

        int SendVehicleTo(int garageSlot, Storage deliveryLocation);

        int UnloadVehicle(int garageSlot);
    }
}
