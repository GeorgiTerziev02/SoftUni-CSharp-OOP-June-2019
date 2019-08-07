namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var vehicle = new SportCar(250, 1125.00);

            vehicle.Drive(70);

            System.Console.WriteLine(vehicle.Fuel);
        }
    }
}
