using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch tm = new System.Diagnostics.Stopwatch();
            tm.Start();
            byte pow = 1 << 5;
            tm.Stop();

            Console.WriteLine($"LeftShift Time : \t {tm.Elapsed.TotalMilliseconds}");

            tm.Reset();
            tm.Start();

            byte mathPow = (byte)Math.Pow(2, 5);
            tm.Stop();

            Console.WriteLine($"Math time: \t\t {tm.Elapsed.TotalMilliseconds}");
        }
    }
}
