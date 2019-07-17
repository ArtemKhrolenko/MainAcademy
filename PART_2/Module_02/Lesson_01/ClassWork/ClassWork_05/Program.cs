using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassWork_05
{
    class Program
    {
        static void Main(string[] args)
        {
            SyncLock();
        }

        #region SyncLock
        static void SyncLock()
        {
            Msg_disp p = new Msg_disp();

            // All following threads are pointing to the same method of the object
            Thread[] thr_arr = new Thread[3];
            for (int j = 0; j < 3; j++)
            {
                thr_arr[j] =
                  new Thread(new ThreadStart(p.Disp_msg));
                thr_arr[j].Name = string.Format("Worker thread thr_arr[{0}]", j);
            }

            foreach (Thread thr in thr_arr)
                thr.Start();
            Console.ReadLine();
        }
        #endregion

        
    }

    public class Msg_disp
    {
        private static object Thrd_lock = new object();
        private string[] Morse_code = new string[]
        {".-   ", "-... ", "-.-. ", "-..  ", ".    ", "..-. ", "--.  ", ".... ", "..   ", ".--- ", "-.-  ", ".-.. ", "--   ", "-.   ", "---  ", ".--. ", "--.- ", ".-.  ", "...  ", "-    ", "..-  ", "...- ", ".--  ", "-..- ", "-.-- ", "--.. ",
        "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----."};

        public void Disp_msg()
        {
            MyLock();
            Console.WriteLine("Lock exiting");
        }
        void MyLock()
        {
            lock (Thrd_lock)
            {
                Console.WriteLine("Thread.CurrentThread.Name {0} in Disp_msg()",
                  Thread.CurrentThread.Name);
                //Emulate a long work
                Console.Write("Random Morse code ");
                for (int i = 0; i < 35; i++)
                {
                    Random rnd = new Random();
                    int j = rnd.Next(0, 36);
                    Thread.Sleep(10* j);
                    Console.Write("{0}", Morse_code[j]);
                }
            }
        }
    }
}
