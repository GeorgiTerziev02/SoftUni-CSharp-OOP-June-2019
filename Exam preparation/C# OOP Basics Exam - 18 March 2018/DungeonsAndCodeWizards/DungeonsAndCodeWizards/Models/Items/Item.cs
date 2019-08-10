using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Models.Contracts;
using System;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item : IItem
    {
        public Item(int weight)
        {
            this.Weight = weight;
        }
        public int Weight { get; private set; }

        public virtual void AffectCharacter(Character character)
        {
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterMustBeAliveException);
            }
        }
    }
}
