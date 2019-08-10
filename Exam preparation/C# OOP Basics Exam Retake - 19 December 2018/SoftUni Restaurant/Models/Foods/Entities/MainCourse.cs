namespace SoftUniRestaurant.Models.Foods.Entities
{
    public class MainCourse : Food
    {
        private const int InitialServingSizeValue = 500;
        public MainCourse(string name, decimal price)
            : base(name, InitialServingSizeValue, price)
        {
        }
    }
}
