using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name,string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
        public string Name { get; private set; }
        public string BirthDate { get; private set; }
    }
}
