using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private const int DefaultCapacityValue = 100;

        private readonly List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = DefaultCapacityValue;
            this.items = new List<Item>();
        }

        public int Load => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public int Capacity { get; protected set; }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.BagIsFullException);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BagIsEmptyException);
            }

            Item itemToFind = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (itemToFind == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemDoesntExistInTheBagException, name));
            }

            this.items.Remove(itemToFind);

            return itemToFind;
            //will it return the item????
        }
    }
}
