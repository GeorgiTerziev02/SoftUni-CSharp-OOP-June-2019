using System;

namespace EnterNumbers
{
    public class Program
    {
        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 100;
        public static void Main(string[] args)
        {
            ReadNumber(MIN_VALUE, MAX_VALUE);
        }

        private static void ReadNumber(int minValue, int maxValue)
        {
            int numbersCount = 0;
            do
            {
                try
                {
                    string currentInput = Console.ReadLine();
                    int currentNumber;

                    bool isParsed = int.TryParse(currentInput, out currentNumber);

                    if (isParsed == false)
                    {
                        numbersCount = 0;
                        throw new ArgumentException("Number should be of type integer" + Environment.NewLine + "Enter the numbers again!");
                    }

                    if (currentNumber <= minValue || currentNumber >= maxValue)
                    {
                        numbersCount = 0;
                        throw new ArgumentException("Number should be in the range [1-100]" + Environment.NewLine + "Enter the numbers again!");
                    }

                    numbersCount++;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            } while (numbersCount < 10);

            Console.WriteLine("You successfully entered 10 integers");
        }
    }
}
