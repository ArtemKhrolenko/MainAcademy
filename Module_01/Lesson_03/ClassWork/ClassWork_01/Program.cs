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
            //int
            Console.WriteLine(7 % 3);
            //int
            Console.WriteLine(7 % -3); //1

            Console.WriteLine(-7 - (-7/3) * 3);

            //Console.ReadLine();

            //double
            Console.WriteLine(7.0 % 3.2);

            //decimal
            Console.WriteLine(7.0m % 3.2m);

            //double
            Console.WriteLine(-7.2 % 3.2);
        }
    }
}
