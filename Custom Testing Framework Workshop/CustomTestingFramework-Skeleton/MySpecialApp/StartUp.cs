using CustomTestingFramework.Runner;
using System;

namespace MySpecialApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var runner = new TestRunner();

            var result =  runner.Run(@"D:\softuni\OOP\Custom Testing Framework Workshop\CustomTestingFramework-Skeleton\CustomTestingFramework.Tests\bin\Debug\netcoreapp2.1\CustomTestingFramework.Tests.dll");

            foreach (var info in result)
            {
                Console.WriteLine(info);
            }
        }
    }
}
