using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] int_arr = new int[5]{ 5,4,3,2,1};
            Array.Sort(int_arr);
            for (int i = 0; i < int_arr.Length; i++)
            {
                Console.WriteLine(int_arr.GetValue(i));
            }
        }
    }
}
