using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_06
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = 1, lim = 10;
            for (int j = 2; j <= lim;)
            {
                res *= j;
                Console.WriteLine("j = " + j + " res = res * j = " + res);
                j++;

            }
            Console.WriteLine("End res = " + res + " . Press any key");
            Console.ReadKey();
        }
    }
}
