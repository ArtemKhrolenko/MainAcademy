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
            try
            {
                do
                {
                    Console.WriteLine(@"Please, type the number: \\n1. To Morse code");
                    string str_a = Console.ReadLine();

                    try
                    {
                        int a = (int)uint.Parse(str_a);
                        switch (a)
                        {
                            case 1:
                                Console.WriteLine("blablabla");
                                //Str_matr_crypt();
                                Console.WriteLine("");
                                break;
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }
                    }
                    catch (FormatException)
                    {

                        Console.WriteLine($"You entered an incorrect number {str_a}");
                        throw;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press SpaceBar to exit; press any key to continue");
                }
                while(Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }
    }
}
