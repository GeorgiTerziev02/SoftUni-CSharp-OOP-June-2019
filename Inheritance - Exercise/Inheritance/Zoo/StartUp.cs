namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Reptile reptile = new Reptile("Pesho");

            System.Console.WriteLine(reptile.Name);
        }
    }
}