using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;
        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.managerController = new ManagerController();
        }
        public void Run()
        {
            string command = reader.ReadLine();

            while (command != "Exit")
            {
                string[] commandArgs = command.Split();

                string output = string.Empty;

                try
                {
                    output = CommandProcessing(commandArgs, output);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }

                if (output != string.Empty)
                {
                    this.writer.WriteLine(output);
                }

                command = reader.ReadLine();
            }
        }

        private string CommandProcessing(string[] commandArgs, string output)
        {
            switch (commandArgs[0])
            {
                case "AddPlayer":
                    {
                        string type = commandArgs[1];
                        string username = commandArgs[2];

                        output = this.managerController.AddPlayer(type, username);
                        break;
                    }

                case "AddCard":
                    {
                        string type = commandArgs[1];
                        string name = commandArgs[2];

                        output = this.managerController.AddCard(type, name);
                        break;
                    }

                case "AddPlayerCard":
                    {
                        string player = commandArgs[1];
                        string card = commandArgs[2];

                        output = this.managerController.AddPlayerCard(player, card);
                        break;
                    }

                case "Fight":
                    {
                        string attacker = commandArgs[1];
                        string enemy = commandArgs[2];

                        output = this.managerController.Fight(attacker, enemy);
                        break;
                    }

                case "Report":
                    {
                        output = this.managerController.Report();
                        break;
                    }
            }

            return output;
        }
    }
}
