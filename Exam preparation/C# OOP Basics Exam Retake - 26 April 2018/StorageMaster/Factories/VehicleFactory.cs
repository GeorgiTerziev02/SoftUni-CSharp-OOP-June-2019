using StorageMaster.Models.Vehicles;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type, int capacity)
        {
            var vehicleType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Vehicle).IsAssignableFrom(t) && t.Name == type && !t.IsAbstract);

            if (vehicleType == null)
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            try
            {
                var vehicle = (Vehicle)Activator.CreateInstance(vehicleType, capacity );

                return vehicle;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}
