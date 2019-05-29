using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    class Derived : Base<Derived>
    {
        public Derived()
        {
            Console.WriteLine("Derived class coonstructor...");
        }
    }
}
