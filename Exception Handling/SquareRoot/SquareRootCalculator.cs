using System;

namespace SquareRoot
{
    public static class SquareRootCalculator
    {

        public static double CalculateSquareRoot(string input)
        {
            int number;
            bool isParsed = int.TryParse(input, out number);

            if (isParsed == false)
            {
                throw new ArgumentException("Number should be of type integer");
            }

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("number", "Number should be positive");
            }

            double result = Math.Sqrt(number);

            return result;
        }
    }
}
