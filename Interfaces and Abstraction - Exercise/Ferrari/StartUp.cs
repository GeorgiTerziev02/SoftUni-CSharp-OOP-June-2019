using System;

namespace Problem03Ferrari
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string driver = Console.ReadLine();

            var ferrari = new Ferrari(driver);

            Console.WriteLine(ferrari.ToString());
        }
    }
}
