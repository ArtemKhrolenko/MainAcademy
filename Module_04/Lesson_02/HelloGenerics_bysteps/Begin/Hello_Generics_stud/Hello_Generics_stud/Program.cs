using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            try
            {
                do
                {
                    Console.WriteLine(@"Please,  type the number:

                        Generics      Class Derived : Base<Derived>
                        1.  Static base constructor
                        2.  Protected base constructor (StackOverflow !)
                        3.  Static base constructor, public field
                        4.  Protected base constructor, static field

                        Generics      Delegats & List
                        5.  Generic delegates, extension methods, List  
                
                        ");
                    try
                    {                        
                        a = int.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:                             
                                Console.WriteLine("Create Derived from static base constructor ...");
                               
                                break;
                            case 2:
                                Console.WriteLine("Create Derived from static base constructor ...");
                                
                                break;
                            case 3:
                                Console.WriteLine("Create Derived from static base constructor ...");
                               
                                break;
                            case 4:
                                Console.WriteLine("Create Derived from static base constructor ...");
                                                                
                                Console.WriteLine("");
                                break;
                            case 5:
                                Console.WriteLine("Create currying ...");
                               
                                Console.WriteLine("");
                                break;
                           
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine("Error");
                    }
                    finally
                    {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}

