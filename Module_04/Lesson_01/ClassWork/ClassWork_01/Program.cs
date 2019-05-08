using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Observation bird flight");
            int ii;
            char rdk;
            try
            {
                do
                {
                    try
                    {
                        Console.WriteLine(@"Please, type the number
                1. subcribe titmouse
                2. subscibe/unsubscribe titmouse
                3. subcribe eagle
                                    ");
                        uint i = uint.Parse(Console.ReadLine());
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("Titmouse");
                                Bird My_Bird = new Bird("Titmouse", 15, 5, 2);
                                //Event handlers, subcribe
                                My_Bird.Startle += My_Bird_Startle;
                                My_Bird.NotSeeing += My_Bird_NotSeeing;

                                for (ii = 5; ii <= My_Bird.FlySpeed; ii++)
                                {
                                    My_Bird.FlyAway(1);
                                }
                                break;
                            case 2:
                                Console.WriteLine("Titmouse");
                                Bird My_Bird1 = new Bird("Titmouse", 15, 5, 2);
                                //Event handlers, subcribe
                                My_Bird1.Startle += My_Bird_Startle;
                                My_Bird1.NotSeeing += My_Bird_NotSeeing;

                                //Unsusribe
                                Console.WriteLine("Unsubcribe");
                                My_Bird1.NotSeeing -= My_Bird_NotSeeing;
                                for (ii = 5; ii <= My_Bird1.FlySpeed; ii++)
                                {
                                    My_Bird1.FlyAway(1);
                                }
                                break;
                            case 3:
                                Console.WriteLine("Eagle");
                                Bird My_Bird3 = new Bird("Eagle", 320, 20, 10);
                                //Event handlers, subcribe
                                My_Bird3.Startle += My_Bird_Startle;
                                My_Bird3.NotSeeing += My_Bird_NotSeeing;

                                for (ii = 20; ii <= 35; ii++)
                                {
                                    My_Bird3.FlyAway(ii);

                                }


                                break;
                            default:
                                break;
                        }
                    }
                    catch (BirdFlewAwayException ev)
                    {
                        Console.WriteLine(ev.Message);
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine("CLS exception: Message -  " + e.Message + " Source - " + e.Source);

                    }
                    finally
                    {
                        Console.WriteLine("For the next step ...");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;


                    rdk = Console.ReadKey().KeyChar;
                } while (rdk != ' ');

            }
            catch (Exception mn)
            {

            }
        }


        static void My_Bird_NotSeeing(object sender, BirdEventsArgs e)
        {
            Console.WriteLine("End ... " + e.TimeReached);
            BirdFlewAwayException ex =
                        new BirdFlewAwayException("Bird flew with incredible speed!",
                                               "Invisible...", DateTime.Now);
            ex.HelpLink = "http://www.example.com";
            throw ex;

        }

        static void My_Bird_Startle(object sender, BirdEventsArgs e)
        {
            // throw new NotImplementedException();
            Console.WriteLine("Oh ... " + e.eventString);
        }
    }


}
