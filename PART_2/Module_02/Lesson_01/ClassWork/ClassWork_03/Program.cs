using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Threading;

namespace ClassWork_03
{
    class Program
    {
        static void Main(string[] args)
        {
            ThrPool();
            
        }

        #region ThreadPool

        static void ThrPool()
        {
            WaitCallback clb = new WaitCallback(Disp_Str);

            ThreadPool.QueueUserWorkItem(clb, "Start");
            ThreadPool.QueueUserWorkItem(clb, "Sleep");
            ThreadPool.QueueUserWorkItem(clb, "Interrupt");
            ThreadPool.QueueUserWorkItem(clb, "Join");

            Console.Read();
        }

        static void Disp_Str(object state)
        {
            string Disp_string = (string)state;

            Console.WriteLine("ThreadId: {0} - {1}", Thread.CurrentThread.ManagedThreadId, Disp_string);
        }
        #endregion
    }
}
