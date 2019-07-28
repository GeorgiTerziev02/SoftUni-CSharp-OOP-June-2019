using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basis_syntax
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int x;
            if (a < b) { x = a; a = b; b = x; }
            if (a < c) { x = a; a = c; c = x; }
            if (b < c) { x = b; b = c; c = x; }


            Console.WriteLine(a);Console.WriteLine(b);Console.WriteLine(c);






        }
    }
}
