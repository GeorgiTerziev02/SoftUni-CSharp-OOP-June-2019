using PlayersAndMonsters.Exceptions;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        public Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrEmptyCardNameException);
                }

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeCardDamagePointsException);
                }

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeCardHealthException);
                }

                this.healthPoints = value;
            }
        }
    }
}
