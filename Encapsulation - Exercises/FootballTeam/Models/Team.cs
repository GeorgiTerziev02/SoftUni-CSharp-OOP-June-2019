using FootballTeam.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeam.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                return (int)(Math.Round(this.players.Average(p => p.OverallStat), 0));
            }
        }
        public string Name
        {

            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyName);
                }

                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var playerToRemove = this.players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MissingPlayer, name, this.Name));
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            if (players.Count == 0)
            {
                return $"{this.Name} - 0";
            }
            return $"{this.Name} - {this.Rating}";
        }

    }
}
