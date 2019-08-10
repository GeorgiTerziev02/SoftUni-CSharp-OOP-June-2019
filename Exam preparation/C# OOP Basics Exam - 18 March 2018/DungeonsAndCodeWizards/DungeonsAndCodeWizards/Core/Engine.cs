using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;
        public Engine(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrEmpty(command))
                {
                    break;
                }

                string[] commandArgs = command.Split(' ');
                string commandName = commandArgs[0];
                string[] args = commandArgs.Skip(1).ToArray();
                string output = string.Empty;

                try
                {

                    switch (commandName)
                    {
                        case "JoinParty":
                            output = this.dungeonMaster.JoinParty(args);
                            break;
                        case "AddItemToPool":
                            output = this.dungeonMaster.AddItemToPool(args);
                            break;
                        case "PickUpItem":
                            output = this.dungeonMaster.PickUpItem(args);
                            break;
                        case "UseItem":
                            output = this.dungeonMaster.UseItem(args);
                            break;
                        case "GiveCharacterItem":
                            output = this.dungeonMaster.GiveCharacterItem(args);
                            break;
                        case "UseItemOn":
                            output = this.dungeonMaster.UseItemOn(args);
                            break;
                        case "GetStats":
                            output = this.dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            output = this.dungeonMaster.Attack(args);
                            break;
                        case "Heal":
                            output = this.dungeonMaster.Heal(args);
                            break;
                        case "EndTurn":
                            output = this.dungeonMaster.EndTurn(args);
                            break;
                    }

                    if (output != string.Empty)
                    {
                        Console.WriteLine(output);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Parameter Error: " + ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Invalid Operation: " + ioe.Message);
                }

                if (dungeonMaster.IsGameOver() == true)
                {
                    break;
                };
                command = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }
    }
}
