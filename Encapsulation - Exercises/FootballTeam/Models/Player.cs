using FootballTeam.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeam.Models
{
    public class Player
    {
        private string name;

        public Player(string name,Stat stat)
        {
            this.Name = name;
            this.Stat = stat;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyName);
                }

                this.name = value;
            }
        }

        public double OverallStat => this.Stat.OverallStat;

        public Stat Stat { get; private set; }
    }
}
