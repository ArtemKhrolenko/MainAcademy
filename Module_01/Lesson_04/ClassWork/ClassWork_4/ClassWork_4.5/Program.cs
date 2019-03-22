using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            
            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(100);
            }

            Console.WriteLine("Source Array: ");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            System.Diagnostics.Stopwatch tm = new System.Diagnostics.Stopwatch();
            tm.Start();

            // Array.Sort(arr);

            tm.Stop();
            Console.WriteLine();
            Console.WriteLine($"LeftShift Time Array.Sort : \t {tm.Elapsed.TotalMilliseconds}");

            tm.Start();
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;

                    }
                }
            }
            tm.Stop();
            Console.WriteLine($"LeftShift Time Bubble.Sort : \t {tm.Elapsed.TotalMilliseconds}");

            //Console.WriteLine();
            //Console.WriteLine("Sorted Array: ");

            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            



        }

    }
}
