using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_fact_advstud
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define parameters to calculate the factorial of
            //Call fact() method to calculate
            Console.WriteLine(GetFactorial(4));
        }

        
        static double GetFactorial(int num)
        {
            if (num == 0)
                return 0;
            if (num == 1)
                return 1;

            return num * GetFactorial(num - 1);
        }
        //Create fact() method  with parameter to calculate factorial
        //Use ternary operator

    }

    

}
