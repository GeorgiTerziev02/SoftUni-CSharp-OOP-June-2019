using System;
using System.Linq;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;
        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                try
                {
                    var commandResult = this.ProcessCommand(command);
                    Console.WriteLine(commandResult);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

                command = Console.ReadLine();
            }

            var summary = this.storageMaster.GetSummary();
            Console.WriteLine(summary);

        }

        private string ProcessCommand(string command)
        {
            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            switch (commandName)
            {
                case "AddProduct":
                    {
                        var name = args[0];
                        var price = double.Parse(args[1]);

                        output = this.storageMaster.AddProduct(name, price);
                        break;
                    }
                case "RegisterStorage":
                    {
                        var type = args[0];
                        var name = args[1];

                        output = this.storageMaster.RegisterStorage(type, name);
                        break;
                    }
                case "SelectVehicle":
                    {
                        var storageName = args[0];
                        var garageSlot = int.Parse(args[1]);

                        output = this.storageMaster.SelectVehicle(storageName, garageSlot);
                        break;
                    }
                case "LoadVehicle":
                    {
                        var productNames = args;

                        output = this.storageMaster.LoadVehicle(productNames);
                        break;
                    }
                case "SendVehicleTo":
                    {
                        var sourceName = args[0];
                        var sourceGarageSlot = int.Parse(args[1]);
                        var destinationName = args[2];

                        output = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                        break;
                    }
                case "UnloadVehicle":
                    {
                        var sourceName = args[0];
                        var garageSlot = int.Parse(args[1]);

                        output = this.storageMaster.UnloadVehicle(sourceName, garageSlot);
                        break;
                    }
                case "GetStorageStatus":
                    {
                        var storageName = args[0];
                        output = this.storageMaster.GetStorageStatus(storageName);
                        break;
                    }
            }

            return output;
        }
    }
}
