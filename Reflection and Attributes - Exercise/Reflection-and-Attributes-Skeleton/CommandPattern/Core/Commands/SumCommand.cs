using System.Linq;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    public class SumCommand : ICommand
    {
        public string Execute(string[] args)
        {
            int[] numbers = args.Select(int.Parse).ToArray();

            long sum = numbers.Sum();

            return $"Current Sum: {sum}";
        }
    }
}
