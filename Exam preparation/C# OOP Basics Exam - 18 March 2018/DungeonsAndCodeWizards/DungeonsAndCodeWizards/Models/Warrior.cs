using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Enumeration;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Models.Bags;
using System;

namespace DungeonsAndCodeWizards.Models
{
    public class Warrior : Character, IAttackable
    {
        private const double DefaultHealth = 100;
        private const double DefaultArmor = 50;
        private const double DefaultAbilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, new Satchel(), faction)
        {
            this.BaseArmor = DefaultArmor;
            this.BaseHealth = DefaultHealth;
            this.Bag = new Satchel();
        }

        public void Attack(Character character)
        {
            if (this.IsAlive == false || character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterMustBeAliveException);
            }

            if (this.Name == character.Name && this.Faction == character.Faction)
            {
                throw new InvalidOperationException(ExceptionMessages.CanNotAttackYourselfException);
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.FriendlyFireException, this.Faction));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
