using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    internal class Calculator
    {
        internal Calculator()
        {
            Console.WriteLine("Calculator");
        }
        internal void StartGame()
        {

            do
            {
                Console.Clear();
                Console.WriteLine("Enter the first operand:");
                Int32.TryParse(Console.ReadLine(), out int firstOperand);

                Console.WriteLine("Enter the second operand number:");
                Int32.TryParse(Console.ReadLine(), out int secondOperand);

                Console.WriteLine("Enter the operator...");
                string someOperator = Console.ReadLine();

                switch (someOperator)
                {
                    case "+":
                        Console.WriteLine($"Result = {firstOperand + secondOperand}");
                        break;

                    case "-":
                        Console.WriteLine($"Result = {firstOperand - secondOperand}");
                        break;

                    case "*":
                        Console.WriteLine($"Result = {firstOperand * secondOperand}");
                        break;

                    case "/":
                        Console.WriteLine($"Result = {(double)firstOperand / (double)secondOperand}");
                        break;
                        
                    default:
                        Console.WriteLine("Unknown operator");
                        break;

                }
                Console.WriteLine("Press Space Button to Exit....");
            }
            while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            

        }
    }
}
