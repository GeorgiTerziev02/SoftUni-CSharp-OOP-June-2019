namespace SoftUniRestaurant.Models.Drinks.Entities
{
    public class Water : Drink
    {
        private const decimal WaterPrice = 1.50M;

        public Water(string name, int servingSize, string brand)
            : base(name, servingSize, WaterPrice, brand)
        {

        }
    }
}
