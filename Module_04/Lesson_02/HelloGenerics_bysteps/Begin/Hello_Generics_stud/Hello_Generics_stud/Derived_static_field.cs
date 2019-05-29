using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class Derived_static_field : Base_static_field<Derived_static_field>
    {
        public Derived_static_field()
        {
            Console.WriteLine("Derived_static_field constructor....");
        }
    }
}
