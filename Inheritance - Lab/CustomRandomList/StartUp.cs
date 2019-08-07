using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList<string> list = new RandomList<string>();

            list.Add("reere");
            list.Add("5eere");
            list.Add("4eere");
            list.Add("6eere");

            Console.WriteLine(list.RandomString());

            Console.WriteLine();


            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
