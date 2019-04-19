using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string genus = "Duck";
            
            Bird duck2 = new SomeDuck(genus);
            duck2.Fly();
            //duck2.Swim();
            duck2.Voice();


           
        }
    }
}
