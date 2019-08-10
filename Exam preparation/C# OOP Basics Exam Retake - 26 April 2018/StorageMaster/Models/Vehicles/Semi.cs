namespace StorageMaster.Models.Vehicles
{
    public class Semi : Vehicle
    {
        private const int TRUCK_INITIAL_CAPACITY = 10;
        public Semi() 
            : base(TRUCK_INITIAL_CAPACITY)
        {

        }
    }
}
