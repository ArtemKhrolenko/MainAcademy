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
            StringBuilder sb = new StringBuilder("TextString");

            sb.Append("new info - ");
            sb.Append(5);
            sb.Insert(11, "!");
            Console.WriteLine(sb);
        }
    }
}
