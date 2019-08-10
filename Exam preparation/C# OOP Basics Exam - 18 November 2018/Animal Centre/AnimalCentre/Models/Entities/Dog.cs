namespace AnimalCentre.Models.Entities
{
    public class Dog : Animal
    {
        public Dog(string name, int energy, int happiness, int proceduredTime) 
            : base(name, energy, happiness, proceduredTime)
        {

        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Dog), Name, Happiness, Energy);
        }
    }
}
