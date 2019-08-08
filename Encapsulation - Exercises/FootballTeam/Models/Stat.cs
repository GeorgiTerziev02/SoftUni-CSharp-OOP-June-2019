using FootballTeam.Exceptions;
using System;

namespace FootballTeam.Models
{
    public class Stat
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;


        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                ValidateStat(value, nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                ValidateStat(value, nameof(this.Sprint));

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                ValidateStat(value, nameof(this.Dribble));

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                ValidateStat(value, nameof(this.Passing));

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                ValidateStat(value, nameof(this.Shooting));

                this.shooting = value;
            }
        }

        public double OverallStat => (this.Endurance + this.Sprint + this.Dribble + this.Shooting + this.Passing) / 5.0;

        private void ValidateStat(int value, string name)
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatException, name));
            }
        }
    }
}
