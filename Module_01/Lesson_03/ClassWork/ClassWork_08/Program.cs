using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_08
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i < 8)
            {                
                while (i < 8)
                {
                    Console.WriteLine(" i = " + i);
                    i++;
                    if (i == 4)
                        goto fin;
                }
            fin:
                Console.WriteLine("Done. i = " + i + ". Press any key");
                i++;
                Console.WriteLine(" i = " + i);
                if (i == 4)
                    break;
               
            }
            i++;
            Console.WriteLine("Done. i = " + i + ". Press any key");
        }
    }
}
