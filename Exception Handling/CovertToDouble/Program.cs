using System;

namespace CovertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //double convertedNumber = Convert.ToDouble(input);

            try
            {
                double.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
