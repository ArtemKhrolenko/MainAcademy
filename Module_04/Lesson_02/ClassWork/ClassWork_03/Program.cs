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
        }
    }

    public interface IgenericList<T, U>
    {
        void Add(T input_data1, U input_data2);
    }

    public class GenericList1<T, U> : IgenericList<T, U>
    {
        public void Add(T input_data1, U input_data2)
        {
            
        }
    }
}
