using System.IO;
using System.Linq;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    public class CreateFileCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string fileName = args[0];

            string content = string.Empty;

            if (args.Length > 1)
            {
                string[] arrayContent = args.Skip(1).ToArray();

                content += string.Join(" ", arrayContent);
            }

            File.WriteAllText(fileName, content);

            return $"File {fileName} created successfully";
        }

        //public string CurretPath => Directory.GetCurrentDirectory();
    }
}
