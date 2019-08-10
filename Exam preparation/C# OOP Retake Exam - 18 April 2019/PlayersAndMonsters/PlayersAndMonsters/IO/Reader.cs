using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
