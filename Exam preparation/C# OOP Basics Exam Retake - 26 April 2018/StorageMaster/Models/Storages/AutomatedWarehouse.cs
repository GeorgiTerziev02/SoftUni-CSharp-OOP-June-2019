using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int INITIAL_CAPACITY = 1;
        private const int INITIAL_GARAGE_SLOTS = 2;
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Truck()
        };

        public AutomatedWarehouse(string name) 
            : base(name, INITIAL_CAPACITY, INITIAL_GARAGE_SLOTS, DefaultVehicles)
        {
            
        }
    }
}
