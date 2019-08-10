namespace AnimalCentre.Models.Entities
{
    public class Cat : Animal
    {
        public Cat(string name, int energy, int happiness, int proceduredTime) 
            : base(name, energy, happiness, proceduredTime)
        {

        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Cat), Name, Happiness, Energy);
        }
    }
}
