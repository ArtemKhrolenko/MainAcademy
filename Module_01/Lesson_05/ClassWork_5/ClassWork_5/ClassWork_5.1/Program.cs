using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Enter first positive number: ");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            a = (int)uint.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Yellow;

            b = (int)uint.Parse(Console.ReadLine());


            string aStr = string.Empty, bStr = string.Empty;

            for (int i = 0; i < a; i++)
            {
                aStr += "1";
            }

            for (int i = 0; i < b; i++)
            {
                bStr += "1";
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"aSTr: {aStr}");
            Console.WriteLine($"bSTr: {bStr}");

            Console.WriteLine();

            Console.WriteLine("Unary result: ");
            for (int i = 0; i < Math.Abs(aStr.Length - bStr.Length); i++)
            {
                Console.Write("1");
            }

            Console.WriteLine();




        }
    }
}
