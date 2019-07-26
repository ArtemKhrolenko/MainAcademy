using System;

namespace ClassWork_01
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Itnro();

        }

        public unsafe static void Itnro()
        {
            int* a;
            int b = 8;
            a = &b;

            Console.WriteLine(*a);
            Console.WriteLine($"b: {b}");
            Console.WriteLine($"Address of b: {(int)a}");
            b = b + 8;
            Console.WriteLine(*a);
            *a = 2;
            Console.WriteLine(b);
        }
    }
}
