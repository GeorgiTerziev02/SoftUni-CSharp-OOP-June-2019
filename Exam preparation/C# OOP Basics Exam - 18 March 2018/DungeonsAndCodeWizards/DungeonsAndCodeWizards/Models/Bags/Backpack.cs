namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Backpack : Bag
    {
        private const int DefaultBackpackCapacityValue = 100;
        public Backpack()
            : base(DefaultBackpackCapacityValue)
        {
            this.Capacity = DefaultBackpackCapacityValue;
        }
    }
}
