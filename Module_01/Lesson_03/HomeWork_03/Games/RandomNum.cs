using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class RandomNum
    {
        internal void StartGame()
        {
            Console.WriteLine("Random Num");

            do
            {
                Console.Clear();
                Console.WriteLine("Enter the maximum number");
                Int32.TryParse(Console.ReadLine(), out int maxNumber);
                
                Console.WriteLine($"Enter your number...");
                Int32.TryParse(Console.ReadLine(), out int myNumber);

                if (maxNumber >= 0)
                {
                    int randNumber = new Random().Next(maxNumber);
                    Console.WriteLine(randNumber != myNumber ? "You are wrong. Try again!" : "You are the Champion!!!!");

                    Console.WriteLine($"Random Number = {randNumber}");
                    Console.WriteLine("Press Space Button to Exit....");
                }
                else
                {
                    Console.WriteLine("Incorrect data!");
                    continue;
                }
                
            }
            while (Console.ReadKey().Key != ConsoleKey.Spacebar);

        }
    }
}
