using System.Text;

namespace Cars
{
    public class Seat : Car, ICar
    {

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.Model}");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
