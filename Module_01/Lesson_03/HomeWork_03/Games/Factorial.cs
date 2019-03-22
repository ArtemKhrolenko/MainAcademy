using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class Factorial
    {
        double getFactorial(int N)
        {
            if (N < 0) 
                return 0;
            if (N == 0) 
                return 1;
            else 
                return N * getFactorial(N - 1); 
        }

        internal void StartGame()
        {
            Console.WriteLine("Factorial");

            do
            {
                Console.Clear();
                Console.WriteLine("Enter the number");
                Int32.TryParse(Console.ReadLine(), out int number);
                Console.WriteLine($"Factorial = {getFactorial(number)}");
                Console.WriteLine("Press Space Button to Exit....");
            }
            while (Console.ReadKey().Key != ConsoleKey.Spacebar);
             

            
        }
    }
}
