namespace AnimalCentre.Models.Entities
{
    public class Lion : Animal
    {
        public Lion(string name, int energy, int happiness, int proceduredTime) 
            : base(name, energy, happiness, proceduredTime)
        {

        }

        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Lion), Name, Happiness, Energy);
        }
    }
}
