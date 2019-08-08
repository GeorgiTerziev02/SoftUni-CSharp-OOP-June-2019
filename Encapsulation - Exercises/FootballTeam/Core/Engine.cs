using FootballTeam.Exceptions;
using FootballTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeam.Core
{
    public class Engine
    {
        private readonly List<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                try
                {
                    string[] tokens = command.Split(";").ToArray();

                    string cmdType = tokens[0];
                    string name = tokens[1];

                    if (cmdType == "Team")
                    {
                        Team team = new Team(name);

                        this.teams.Add(team);
                    }
                    else if (cmdType == "Add")
                    {
                        ValidateTeam(name);
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Stat stat = new Stat(endurance, sprint, dribble, passing, shooting);

                        Player player = new Player(playerName, stat);

                        Team team = this.teams.FirstOrDefault(t => t.Name == name);

                        team.AddPlayer(player);

                    }
                    else if (cmdType == "Remove")
                    {
                        ValidateTeam(name);

                        Team team = this.teams.First(t => t.Name == name);

                        team.RemovePlayer(tokens[2]);
                    }
                    else if (cmdType == "Rating")
                    {
                        ValidateTeam(name);
                        Team team = this.teams.First(t => t.Name == name);

                        Console.WriteLine(team.ToString());
                    }


                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }

        }
        private void ValidateTeam(string name)
        {
            Team team = this.teams.FirstOrDefault(t => t.Name == name);

            if (team == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingTeam, name));
            }
        }
    }
}
