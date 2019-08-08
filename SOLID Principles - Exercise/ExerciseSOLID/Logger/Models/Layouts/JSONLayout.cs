using System.Text;

using Logger.Models.Contracts;

namespace Logger.Models.Layouts
{
    public class JSONLayout : ILayout
    {
        public string Format => GetFromat();

        private string GetFromat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\"log\":[")
                .AppendLine("\t\"date\": \"{0}\",")
                .AppendLine("\t\"level\": \"{1}\",")
                .AppendLine("\t\"message\": \"{2}\"")
                .AppendLine("]");

            return sb.ToString().TrimEnd();
        }
    }
}
