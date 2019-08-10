using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Models.Items;
using System;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            if (itemName != "ArmorRepairKit" && itemName != "HealthPotion" && itemName != "PoisonPotion")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItemException, itemName));
            }

            Item item = null;

            if (itemName == "ArmorRepairKit")
            {
                item = new ArmorRepairKit();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if(itemName == "PoisonPotion")
            {
                item = new PoisonPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItemException, itemName));
            }

            return item;
        }
    }
}
