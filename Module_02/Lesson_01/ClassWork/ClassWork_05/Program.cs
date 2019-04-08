using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_05
{

    class Program
    {
        static void Main(string[] args)
        {
            var int_Arr = new[] { 0, 1, 2 };
            var str_Arr = new[] { "Hello", "Array", null };

            var nullable_intArr = new[] { 0, (int?)1, 2 };
            

            int? a = nullable_intArr[1] ?? 4;
            Console.WriteLine(a);

            Console.WriteLine(int_Arr.GetType());
            Console.WriteLine(str_Arr.GetType());

            Console.WriteLine(nullable_intArr.GetType());
            Console.WriteLine(nullable_intArr.GetLength(0));
        }
    }
}
