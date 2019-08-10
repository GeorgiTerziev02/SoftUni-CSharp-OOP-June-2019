namespace SoftUniRestaurant.Models.Foods.Entities
{
    public class Dessert : Food
    {
        private const int InitialServingSizeValue = 200;
        public Dessert(string name, decimal price)
            : base(name, InitialServingSizeValue, price)
        {
        }
    }
}
