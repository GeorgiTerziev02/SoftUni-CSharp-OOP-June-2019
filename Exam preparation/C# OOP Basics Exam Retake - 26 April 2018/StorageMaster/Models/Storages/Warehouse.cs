using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        private const int INITIAL_CAPACITY = 10;
        private const int INITIAL_GARAGE_SLOTS = 10;
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Semi(), new Semi(), new Semi()
        };

        public Warehouse(string name)
            : base(name, INITIAL_CAPACITY, INITIAL_GARAGE_SLOTS, DefaultVehicles)
        {

        }
    }
}
