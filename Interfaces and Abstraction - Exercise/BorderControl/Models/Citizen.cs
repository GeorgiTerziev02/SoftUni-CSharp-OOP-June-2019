using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private int food;
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
            this.food = 0;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string BirthDate { get; private set; }

        public int Food
        {
            get
            {
                return this.food;
            }
        }

        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
