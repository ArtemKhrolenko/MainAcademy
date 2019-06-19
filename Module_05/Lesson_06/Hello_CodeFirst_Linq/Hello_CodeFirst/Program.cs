using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.EntityClient;
using System.Data;

namespace Hello_CodeFirst_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new tect_CodeFirstLingContext())
            {
                List<string> script = null;
                try
                {
                    try
                    {
                         DB_init(ctx);
                    }
                    catch (Exception)
                    {
                        Console.Write("Initialization error ?\r\n");
                    }
                    int a;
                    
                    do
                    {
                        Console.WriteLine(@"Please,  type the number:                       
                        1.  Clear and insert to the DB by script
                        2.  Insert lecturer with email (one-to-many)
                        3.  Delete lecturer with email (one-to-many)
                        4.  Add new email to lecturer
                        5.  Update lecturer
                       
                        ");
                        try
                        {
                            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                            a = int.Parse(Console.ReadLine());
                            switch (a)
                            {
                                case 1:
                                    Console.WriteLine("Clear and insert to the DB by script  ");
                                    
                                    break;
                                case 2:
                                    Console.WriteLine("Insert lecturer with email (one-to-many) ");
                                    
                                    break;
                                case 3:
                                    Console.WriteLine("Delete lecturer with email (one-to-many) ");
                                    
                                    break;
                                case 4:
                                    Console.WriteLine("Add new email to lecturer ");
                                   

                                    break;
                                case 5:
                                    Console.WriteLine("Update lecturer name ");
                                    
                                  
                                    break;
                                default:
                                    Console.WriteLine("Exit");
                                    break;
                            }

                        }
                        catch (System.Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }
                        finally
                        {
                            Console.ReadLine();
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

                Console.ReadKey();
               
            }
        }


        static void DB_init(tect_CodeFirstLingContext ctx)
        {
            // Initialize database at this moment
            ctx.Database.Initialize(false);
        }


      
    }
}

