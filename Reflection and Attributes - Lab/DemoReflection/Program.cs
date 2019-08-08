using System;

namespace DemoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "ivan";
            Type type = Type.GetType(str);

            var classInstance = Activator.CreateInstance(type);
            Console.WriteLine(type.BaseType);
        }
    }
}
