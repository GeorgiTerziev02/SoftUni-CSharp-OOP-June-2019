namespace SoftUniRestaurant.Models.Foods.Entities
{
    public class Soup : Food
    {
        private const int InitialServingSizeValue = 245;
        public Soup(string name, decimal price)
            : base(name, InitialServingSizeValue, price)
        {

        }
    }
}
