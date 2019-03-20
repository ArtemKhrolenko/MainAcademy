using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                result = i & 0xFFFE;

                Console.WriteLine($"{result}");
            }

            Console.WriteLine(0xFFFE);
            Console.WriteLine(ushort.MaxValue);
        }
    }
}
