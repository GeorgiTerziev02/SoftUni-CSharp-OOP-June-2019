namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double airConditioner = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm + airConditioner, tankCapacity)
        {

        }
    }
}
