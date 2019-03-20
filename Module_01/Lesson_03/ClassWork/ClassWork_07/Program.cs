using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 0;
            int i = 0;
            while (i < 8)
            {
                j++;

                i++;
                if (i == 4)
                {
                    i++;
                    continue;
                }

            }
            Console.WriteLine("Done. i = "+i + ". Press any key");
            Console.WriteLine(j);
        }
    }
}
