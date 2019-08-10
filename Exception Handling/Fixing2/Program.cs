using System;

namespace Fixing2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num1, num2;
                byte result;

                num1 = 30;
                num2 = 60;

                result = Convert.ToByte(num1 * num2);
                Console.WriteLine(num1 + " x " + num2 + " = " + result);
                Console.ReadLine();
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                Console.WriteLine("Byte varies from 0 to 255");
            }
        }
    }
}
