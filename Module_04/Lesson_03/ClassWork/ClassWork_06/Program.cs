using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;


namespace ClassWork_06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> intList = new List<string>();
            intList.Add("");
            intList.Add(null);
            intList.Add(null);
            intList.Add(null);

            
            Console.WriteLine(intList.Count);
        }
    }
}
