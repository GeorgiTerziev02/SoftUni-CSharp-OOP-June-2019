using System;

namespace SquareRoot
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                double result = SquareRootCalculator.CalculateSquareRoot(input);
                Console.WriteLine(result);
            }
            catch(ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
