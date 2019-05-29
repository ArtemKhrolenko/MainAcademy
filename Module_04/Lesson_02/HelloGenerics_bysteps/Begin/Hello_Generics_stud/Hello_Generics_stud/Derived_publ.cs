using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    class Derived_publ : Base_publ<Derived_publ>
    {
        public Derived_publ()
        {
            Console.WriteLine("      Derived constructor");
        }
    }
}
