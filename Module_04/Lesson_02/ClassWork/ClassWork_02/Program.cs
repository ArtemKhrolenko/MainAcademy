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
            GenericList<int, string> list1 = new GenericList<int, string>();

            GenericList<string, GenericList<int, string>> list2 = new GenericList<string, GenericList<int, string>>();

            GenericList<SomeTestClass, object> list3 = new GenericList<SomeTestClass, object>();
        }
    }

    public class GenericList<T, U>:IgenericList<T,U>
    {
       

        public void Add(T input_data1, U input_data2)
        {
            throw new NotImplementedException();
        }
    }

    public interface IgenericList<T, U>
    {
        void Add(T input_data1, U input_data2);
    }
    public class SomeTestClass{ }
}
