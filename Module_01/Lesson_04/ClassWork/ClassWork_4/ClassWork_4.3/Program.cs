using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //suggest value will not be find
            int position = -1;

            //searching of position of last element equals 2
            
            int[] int_array = new int[] { 0, 5, 8, 2, 4 };

            for (int i = 0; i < int_array.Length; i++)
            {
                if (int_array[i] == 2)
                {
                    position = i;
                }
            }
            Console.WriteLine($"Position = {position}");
        }
    }
}
