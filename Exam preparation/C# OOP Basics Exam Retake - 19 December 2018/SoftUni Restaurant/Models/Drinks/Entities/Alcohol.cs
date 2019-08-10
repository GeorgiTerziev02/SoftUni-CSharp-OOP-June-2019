namespace SoftUniRestaurant.Models.Drinks.Entities
{
    public class Alcohol : Drink
    {
        private const decimal AlchoholPrice = 3.50M;

        public Alcohol(string name, int servingSize, string brand)
            : base(name, servingSize, AlchoholPrice, brand)
        {

        }
    }
}
