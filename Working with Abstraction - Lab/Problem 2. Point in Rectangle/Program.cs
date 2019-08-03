using System;
using System.Linq;

namespace Problem2.PointinRectangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = ParseInput();

            Point topLeft = new Point(input[0], input[1]);
            Point bottomRight = new Point(input[2], input[3]);

            var rectangle = new Rectangle(topLeft, bottomRight);

            int numberOfRows = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRows; i++)
            {
                int[] coordinatesOfPoint = ParseInput();

                Point pointToCheck = new Point(coordinatesOfPoint[0], coordinatesOfPoint[1]);

                Console.WriteLine(rectangle.Contains(pointToCheck));
            }
        }

        private static int[] ParseInput()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
