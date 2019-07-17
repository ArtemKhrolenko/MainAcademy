using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassWork_01
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstThread();
        }

        public static void OnlyThreadMeth()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("Ciunter : {0}, thread: {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }
            
        }

        public static void FirstThread()
        {
            Thread thr_1 = new Thread(OnlyThreadMeth);
            Thread thr_2 = new Thread(OnlyThreadMeth);

            thr_1.Start();
            thr_2.Start();

            thr_1.Join();
            thr_2.Join();


            Console.WriteLine("End Main");
            Console.Read();

        }
    }
}
