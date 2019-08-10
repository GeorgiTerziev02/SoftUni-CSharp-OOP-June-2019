using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {
        private const int INITIAL_CAPACITY = 2;
        private const int INITIAL_GARAGE_SLOTS = 5;
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Van(), new Van(), new Van()
        };

        public DistributionCenter(string name)
            : base(name, INITIAL_CAPACITY, INITIAL_GARAGE_SLOTS, DefaultVehicles)
        {

        }
    }
}
