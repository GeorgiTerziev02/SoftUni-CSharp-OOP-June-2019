using System;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] weekdays = new string[5];
                weekdays[0] = "S";
                weekdays[1] = "M";
                weekdays[2] = "Tues";
                weekdays[3] = "Wed";
                weekdays[4] = "Thur";

                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
                Console.ReadLine();
            }
            catch (IndexOutOfRangeException iore)
            {
                Console.WriteLine(iore.Message);
            }

        }
    }
}
