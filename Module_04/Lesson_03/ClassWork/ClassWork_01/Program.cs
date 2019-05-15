using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class Gen
    {
        public virtual void SOmeMet() { Console.WriteLine("Gen"); }
    }

    class BAse : Gen { public override void SOmeMet() { Console.WriteLine("Base"); } }
    class Derived : BAse {  public override void SOmeMet() { Console.WriteLine("Der"); } }
    class Program
    {
        public delegate T SampleGenericDelegate<out T>(); //cow
        static void Main(string[] args)
        {           

            //(str) => Console.WriteLine(str.ToString());

            Action<BAse> aDel1 = aDel1 = new Action<BAse>(Method);         

            aDel1(new Derived());
            
        }

        public static void Method(Gen par){par.SOmeMet(); }
    }
}
