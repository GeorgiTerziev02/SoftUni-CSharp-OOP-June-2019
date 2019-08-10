namespace AnimalCentre.Models.Entities
{
    public class Pig : Animal
    {
        public Pig(string name, int energy, int happiness, int proceduredTime) 
            : base(name, energy, happiness, proceduredTime)
        {

        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Pig), Name, Happiness, Energy);
        }
    }
}
