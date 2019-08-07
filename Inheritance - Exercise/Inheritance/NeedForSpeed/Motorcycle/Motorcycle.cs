namespace NeedForSpeed
{
    public class Motorcycle : Vehicle
    {
        private const double DefaultFuelConsumption = 8;
        public Motorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
