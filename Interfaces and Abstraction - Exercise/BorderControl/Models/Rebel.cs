using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Rebel : IBuyer
    {
        private int food;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.food = 0;
        }
        public string Name { get; private set; }

        public int Age { get; set; }

        public string Group { get; private set; }

        public int Food
        {
            get
            {
                return this.food;
            }
        }

        public void BuyFood()
        {
            this.food += 5;
        }
    }
}
