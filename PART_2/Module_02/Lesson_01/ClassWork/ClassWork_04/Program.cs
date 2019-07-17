using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Shr();
        }

        #region Sharing
        static void Shr()
        {
            Msg_back WorkThr = new Msg_back();
            WorkThr.Msg = "Are you present?";
            new Thread(WorkThr.Reply).Start();            
            new Thread(WorkThr.ChangeAns).Start();

            Console.WriteLine("Press any key ");
            Console.ReadLine();
            Console.WriteLine(WorkThr.Answ);
        }
        #endregion

    }

    public class Msg_back
    {
        public string Msg;
        public volatile string Answ;

        public void Reply()
        {
            Console.WriteLine("Worker thread. Msg field:" + Msg);
            for (int i = 0; i < 5; i++)
            {
                Answ = Answ + "!";
            }
        }

        public void ChangeAns()
        {
            for (int i = 0; i < 5; i++)
            {
                Answ = Answ + "!";
            }

        }
    }
}
