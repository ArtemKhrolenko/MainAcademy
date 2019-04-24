using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird1 = new Bird("Duck");
            Bird bird2 = (Bird)bird1.Clone();
            Bird bird3 = bird2.ShalowCopy();

            Console.WriteLine(bird3.Genus);

          Bird b = new Bird{Genus = ""};
        }
    }
}
