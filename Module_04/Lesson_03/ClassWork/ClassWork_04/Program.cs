using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClassWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> sortedList1 = new SortedList<int, string>();
            sortedList1.Add(3, "Three");
            sortedList1.Add(4, "Four");
            sortedList1.Add(1, "One");
            sortedList1.Add(5, "Five");
            sortedList1.Add(2, "Two");

            SortedList<string, int> sortedList2 = new SortedList<string, int>();
            sortedList2.Add("one", 1);
            sortedList2.Add("two", 2);
            sortedList2.Add("three", 3);
            sortedList2.Add("four", 4);

            SortedList<double, int?> sortedList3 = new SortedList<double, int?>();
            sortedList3.Add(1.5, 100);
            sortedList3.Add(3.5, 200);
            sortedList3.Add(2.4, 300);
            sortedList3.Add(2.3, null);
            sortedList3.Add(1.1, null);

            foreach (var item in sortedList3)
            {
                Console.WriteLine(item);
            }            

        }
    }
}
