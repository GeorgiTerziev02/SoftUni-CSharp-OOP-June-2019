using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Enumeration;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Models.Bags;
using System;

namespace DungeonsAndCodeWizards.Models
{
    public class Cleric : Character, IHealable
    {

        private const double DefaultHealth = 50;
        private const double DefaultArmor = 25;
        private const double DefaultAbilityPoints = 40;
        private const double DefaultRestHealMultiplier = 0.5;

        public Cleric(string name, Faction faction)
            : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, new Backpack(), faction)
        {
            this.RestHealMultiplier = DefaultRestHealMultiplier;
            this.BaseArmor = DefaultArmor;
            this.BaseHealth = DefaultHealth;
            this.Bag = new Backpack();
        }

        public void Heal(Character character)
        {
            if (this.IsAlive == false || character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterMustBeAliveException);
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(ExceptionMessages.CanNotHealEnemyException);
            }

            character.Health += this.AbilityPoints;

            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
