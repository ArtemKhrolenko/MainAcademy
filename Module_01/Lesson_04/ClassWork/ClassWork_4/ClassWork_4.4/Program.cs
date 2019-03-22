using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClassWork_4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr1 = { { 2, 4, 6, 8 }, { 2, 4, 6, 8 } };
            int[,] arr2 = { { 2, 4, 6, 8 }, { 2, 4, 6, 8 } };
            //suggest arrays are equals

            bool flag = true;

            //arr1 = arr2 (without size checking)
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    if (arr1[i, j] != arr2[i, j])
                        flag = false;
                }
            }            

            Console.WriteLine($"Flag = {flag}");

            
           

        }
    }
}
