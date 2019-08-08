using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Foods.Entities
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
