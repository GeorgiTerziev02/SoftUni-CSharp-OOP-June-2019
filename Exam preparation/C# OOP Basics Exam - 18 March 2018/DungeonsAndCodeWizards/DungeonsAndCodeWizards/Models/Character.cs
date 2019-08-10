using DungeonsAndCodeWizards.Enumeration;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Character
    {
        private string name;
        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;

            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.Bag = bag;
            this.AbilityPoints = abilityPoints;
            this.Faction = faction;
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
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespaceException);
                }

                this.name = value;
            }
        }

        public double Health { get; set; }

        public double BaseHealth { get; protected set; }

        public bool IsAlive { get; set; }

        public double Armor { get; set; }

        public double BaseArmor { get; protected set; }

        public double AbilityPoints { get; protected set; }

        public Bag Bag { get; protected set; }

        public Faction Faction { get; protected set; }

        public virtual double RestHealMultiplier { get; protected set; }

        public void TakeDamage(double hitPoints)
        {
            CheckIfCharacterIsAlive();

            if (this.Armor > 0)
            {
                this.Armor -= hitPoints;

                if (this.Armor < 0)
                {
                    this.Health -= Math.Abs(this.Armor);
                    this.Armor = 0;

                    if (this.Health <= 0)
                    {
                        this.Health = 0;
                        this.IsAlive = false;
                    }
                }
            }
            else if (this.Armor <= 0)
            {
                this.Health -= hitPoints;

                if (this.Health <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            CheckIfCharacterIsAlive();

            this.Health += this.BaseHealth * this.RestHealMultiplier;
            if (this.Health > this.BaseHealth)
            {
                this.Health = BaseHealth;
            }
        }

        public void UseItem(Item item)
        {
            CheckIfCharacterIsAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckIfCharacterIsAlive();

            if (character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterMustBeAliveException);
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckIfCharacterIsAlive();

            if (character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterMustBeAliveException);
            }

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            CheckIfCharacterIsAlive();
            
            this.Bag.AddItem(item);
        }

        private void CheckIfCharacterIsAlive()
        {
            if (this.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterMustBeAliveException);
            }
        }

        public override string ToString()
        {
            string isAlive = "";

            if (this.IsAlive == true)
            {
                isAlive = "Alive";
            }
            else
            {
                isAlive = "Dead";
            }

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {isAlive}";
        }
    }
}
