using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class Base_publ<T> where T : new()
    {
        static Base_publ()
        {
            Console.WriteLine("Base_publ static constructor");
            T instance = new T();
        }

        private T _instance;
        public T Instance
        {
            get
            {
                Console.WriteLine("Public field");
                _instance = new T();
                return _instance;
            }
        }
    }
}
