using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();

                string result = this.commandInterpreter.Read(commandLine);

                Console.WriteLine(result);
            }
        }
    }
}
