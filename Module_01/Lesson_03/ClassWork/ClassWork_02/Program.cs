using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0, j = 0; i = i + 1;
            Console.WriteLine("Addition i = " +i);
            i = 0; j = 0; i++; //postfix

            Console.WriteLine("Incrementing (postfix, i = i++) i = " + i);
            i = 0; j = 0; i = ++i; // prefix

            Console.WriteLine("Incrementing (prefix, i = ++i) i = " + i);
            i = 0; j = 0; j = i + 1;

            Console.WriteLine("Addition j = i+1 = " + j + ", i = " + i);
            i = 0; j = 0; j = i++;

            Console.WriteLine("Incrementing (postfix) j = i++ = " + j + ", i = " + i);

            i = 0; j = 0; j = ++i;

            Console.WriteLine("Incrementing (prefix) j = ++i =" + j + ", i= " + i);
        }
    }
}
