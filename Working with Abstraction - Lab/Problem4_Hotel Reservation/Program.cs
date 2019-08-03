using System;

namespace Problem4_Hotel_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var priceCalculator = new PriceCalculator(input);

            Console.WriteLine(priceCalculator.GetTotalPrice().ToString("f2"));
        }
    }
}
