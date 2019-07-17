using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassWork_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Intrrpt();
        }

        #region Interrupt
        public static Thread mother;
        public static Thread son;
        public static void Intrrpt()
        {
            mother = new Thread(new ThreadStart(MotherSleep));
            son = new Thread(new ThreadStart(ChildWoke));
            mother.Start();
            son.Start();
            mother.Join();
            son.Join();
            Console.WriteLine("Exiting Interrupt");
            Console.ReadLine();
        }

        private static void MotherSleep()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write(" m ");
                if ((i % 10 == 0) & (i != 0))
                {
                    try
                    {
                        Console.WriteLine("Mother counter control: {0}, thread: {1}. ", i, Thread.CurrentThread.ManagedThreadId + " Mother will sleep");
                        Thread.Sleep(20);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine("Mother catch ThreadInterruptedException. Get up! ");
                    }
                    Console.WriteLine("Ok");
                }
            }
        }
        private static void ChildWoke()
        {
            for (int i = 1; i < 50; i++)
            {
                Console.Write(" c ");
                if (mother.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Console.WriteLine("Child check Mother.ThreadState == ThreadState.WaitSleepJoin. Interrupting mother");
                    mother.Interrupt();
                }
            }

        }
        #endregion
    }
}
