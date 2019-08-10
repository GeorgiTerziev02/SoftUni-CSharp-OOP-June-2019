using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private Models.AnimalCentre centerController;
        private Dictionary<string, List<string>> adoptedAnimals;
        public Engine()
        {
            this.centerController = new Models.AnimalCentre();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                string output = string.Empty;
                try
                {
                    string[] args = command.Split(" ").ToArray();
                    string[] regData = args.Skip(1).ToArray();
                    string procedureName = args[0];

                    switch (args[0])
                    {
                        case "RegisterAnimal":

                            var animal = regData[0];
                            var name = regData[1];
                            var energy = int.Parse(regData[2]);
                            var happiness = int.Parse(regData[3]);
                            var playTime = int.Parse(regData[4]);
                            output = this.centerController.RegisterAnimal(animal, name, energy, happiness, playTime);
                            break;
                        case "Chip":
                            string animalName = regData[0];
                            int procedureTime = int.Parse(regData[1]);
                            output = this.centerController.Chip(animalName, procedureTime);
                            break;
                        case "Play":
                            string playName = regData[0];
                            int playProcTime = int.Parse(regData[1]);
                            output = this.centerController.Play(playName, playProcTime);
                            break;
                        case "Fitness":
                            string fitnessName = regData[0];
                            int fitnessTime = int.Parse(regData[1]);
                            output = this.centerController.Fitness(fitnessName, fitnessTime);
                            break;
                        case "NailTrim":
                            string nailTrimName = regData[0];
                            int nailTrimTime = int.Parse(regData[1]);
                            output = this.centerController.NailTrim(nailTrimName, nailTrimTime);
                            break;
                        case "Vaccinate":
                            string vaccinateName = regData[0];
                            int vaccinateTime = int.Parse(regData[1]);
                            output = this.centerController.Vaccinate(vaccinateName, vaccinateTime);
                            break;
                        case "DentalCare":
                            string dentalName = regData[0];
                            int dentalTime = int.Parse(regData[1]);
                            output = this.centerController.DentalCare(dentalName, dentalTime);
                            break;
                        case "Adopt":
                            string adoptAnimal = regData[0];
                            string owner = regData[1];
                            output = this.centerController.Adopt(adoptAnimal, owner);
                            if(!adoptedAnimals.ContainsKey(owner))
                            {
                                adoptedAnimals.Add(owner, new List<string>());
                            }
                            adoptedAnimals[owner].Add(adoptAnimal);
                            break;
                        case "History":
                            output = this.centerController.History(args[1]);
                            break;
                    }

                    Console.WriteLine(output);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("ArgumentException: " + ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("InvalidOperationException: " + ioe.Message);
                }

                command = Console.ReadLine();
            }

            if(this.adoptedAnimals.Count!=0)
            {
                foreach (var owner in adoptedAnimals.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"--Owner: {owner.Key}");
                    Console.WriteLine($"    - Adopted animals: {string.Join(" ", owner.Value)}");

                }
            }
        }
    }
}
