using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            byte y;
            int sum = 0;

            for (y = 1; y <= 50; y++)
            {
                sum = sum + y;
            }

            Console.WriteLine($"Sum from 1 to 50 equals {sum}");
            Console.ReadLine();

            

            


        }
    }
}
