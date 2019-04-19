using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Container cntr = new Container(5);

            Container.Nested2 nested = new Container.Nested2(cntr, 5);

            Console.WriteLine();
        }
    }
}
