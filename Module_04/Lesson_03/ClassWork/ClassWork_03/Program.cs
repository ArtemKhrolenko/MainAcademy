using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClassWork_03
{
    class Program
    {
        static void Main(string[] args)
        {
         Hashtable ht = new Hashtable();
            
            ht.Add(1, "One");
            ht.Add(2, "Two");
            ht.Add(3, "Three");
            ht.Add(4, "Four");
            ht.Add("Fv", "Five");
            ht.Add(8.5F, 8.5F);

            string strValue1 = (string)ht[2];
            string strValue2 = (string)ht["Fv"];
            float fValue = (float) ht[8.5F];

            Console.WriteLine(strValue1);
            Console.WriteLine(strValue2);
            Console.WriteLine(fValue);

            foreach(var item in ht)
            {
                //Console.WriteLine($"key: {item.Key}, value {item.Value}");                
            }

            ht.Remove("Fv");
            


        }
    }
}
