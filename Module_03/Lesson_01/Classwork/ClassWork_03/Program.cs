using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int d = 0;

            try
            {
                unchecked
                {                   
                    d = int.Parse(Console.ReadLine());
                }
            }
            catch(OverflowException e)
            {
                Console.WriteLine($"The result value exceeds limits {int.MaxValue}");
            }
            Console.WriteLine(d);
        }
    }
}
