using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClassWork_02
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(1);
            myArrayList.Add("Two");
            myArrayList.Add(3);
            myArrayList.Add(4.5f);

            //Access individual item using indexer
            int firstelement = (int) myArrayList[0];
            string secondElement = (string) myArrayList[1];
            int thirsElement = (int) myArrayList[2];
            float fourthElement = (float) myArrayList[3];

            var first = myArrayList[0];
        }
    }
}
