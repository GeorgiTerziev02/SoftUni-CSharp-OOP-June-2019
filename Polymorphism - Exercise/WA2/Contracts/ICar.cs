namespace Vehicles.Contracts
{
    public interface ICar :IVehicle
    {
        void Drive(double distance);

        void Refuel(double fuel);

    }
}
