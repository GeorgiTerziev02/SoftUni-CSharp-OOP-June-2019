using MortalEngines.Core.Contracts;
using System;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager machinesManager;
        public Engine()
        {
            machinesManager = new MachinesManager();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Quit")
            {
                string[] commandArgs = command.Split();
                string output = null;

                try
                {
                    switch (commandArgs[0])
                    {
                        case "HirePilot":
                            output = this.machinesManager.HirePilot(commandArgs[1]);
                            break;
                        case "PilotReport":
                            output = this.machinesManager.PilotReport(commandArgs[1]);
                            break;
                        case "ManufactureTank":
                            output = this.machinesManager.ManufactureTank(commandArgs[1], double.Parse(commandArgs[2]), double.Parse(commandArgs[3]));
                            break;
                        case "ManufactureFighter":
                            output = this.machinesManager.ManufactureFighter(commandArgs[1], double.Parse(commandArgs[2]), double.Parse(commandArgs[3]));
                            break;
                        case "MachineReport":
                            output = this.machinesManager.MachineReport(commandArgs[1]);
                            break;
                        case "AggressiveMode":
                            output = this.machinesManager.ToggleFighterAggressiveMode(commandArgs[1]);
                            break;
                        case "DefenseMode":
                            output = this.machinesManager.ToggleTankDefenseMode(commandArgs[1]);
                            break;
                        case "Engage":
                            output = this.machinesManager.EngageMachine(commandArgs[1], commandArgs[2]);
                            break;
                        case "Attack":
                            output = this.machinesManager.AttackMachines(commandArgs[1], commandArgs[2]);
                            break;
                    }

                    if (output != null)
                    {
                        Console.WriteLine(output);
                    }
                }
                catch (ArgumentNullException e)
                {

                    Console.WriteLine("Error: " + e.Message);
                }


                command = Console.ReadLine();
            }
        }
    }
}
