using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class Program
    {
        static void Main(string[] args)
        {
            long a;
            Console.WriteLine(@"Please,  type the number:
            1. Farmer, wolf, goat and cabbage puzzle
            2. Console calculator
            3. Factirial calculation
            4. Guess the number Game
            ");

            a = long.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    //Farmer_puzzle();
                    new Farmer().StartGame();
                    Console.WriteLine("");
                    break;
                case 2:
                    new Calculator().StartGame();
                    Console.WriteLine("");
                    break;
                case 3:
                    new Factorial().StartGame();
                    Console.WriteLine("");
                    break;

                case 4:
                    new RandomNum().StartGame();
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Exit");
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}
