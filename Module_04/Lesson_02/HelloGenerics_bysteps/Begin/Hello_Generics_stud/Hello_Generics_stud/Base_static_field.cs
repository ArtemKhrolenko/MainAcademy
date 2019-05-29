using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class Base_static_field<T> where T : new()
    {
        protected Base_static_field()
        {
            Console.WriteLine("Base_static_field protected constructor...");
        }

        private static T _instance;
        public static T Instance
        {
            get
            {
                Console.WriteLine("Static field");
                _instance = new T();
                return _instance;
            }
        }
    }
}
