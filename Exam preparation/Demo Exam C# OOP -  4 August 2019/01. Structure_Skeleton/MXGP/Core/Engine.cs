using MXGP.Core.Contracts;
using System;
using System.Linq;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;

        public Engine()
        {
            this.championshipController = new ChampionshipController();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while(command!="End")
            {
                string[] commandArgs = command.Split(" ");
                string currentCommand = commandArgs[0];
                string[] args = commandArgs.Skip(1).ToArray();

                string output = string.Empty;

                try
                {
                    switch (currentCommand)
                    {
                        case "CreateRider":
                            output = this.championshipController.CreateRider(args[0]);
                            break;
                        case "CreateMotorcycle":
                            output = this.championshipController.CreateMotorcycle(args[0], args[1], int.Parse(args[2]));
                            break;
                        case "AddMotorcycleToRider":
                            output = this.championshipController.AddMotorcycleToRider(args[0], args[1]);
                            break;
                        case "AddRiderToRace":
                            output = this.championshipController.AddRiderToRace(args[0], args[1]);
                            break;
                        case "CreateRace":
                            output = this.championshipController.CreateRace(args[0], int.Parse(args[1]));
                            break;
                        case "StartRace":
                            output = this.championshipController.StartRace(args[0]);
                            break;
                    }

                    Console.WriteLine(output);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
