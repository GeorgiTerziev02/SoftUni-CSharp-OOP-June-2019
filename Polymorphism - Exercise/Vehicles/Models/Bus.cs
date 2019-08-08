namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double airConditioner = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm + airConditioner, tankCapacity)
        {

        }

        public void DriveEmpty(double distance)
        {
            this.FuelConsumptionPerKm -= 1.4;
            base.Drive(distance);
        }
    }
}
