namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Satchel : Bag
    {
        private const int DefaultSatchelCapacityValue = 20;

        public Satchel() 
            : base(DefaultSatchelCapacityValue)
        {
            this.Capacity = DefaultSatchelCapacityValue;
        }
    }
}
