namespace SoftUniRestaurant.Models.Foods.Entities
{
    public class Salad : Food
    {
        private const int InitialServingSizeValue = 300;
        public Salad(string name, decimal price)
            : base(name, InitialServingSizeValue, price)
        {

        }
    }
}
