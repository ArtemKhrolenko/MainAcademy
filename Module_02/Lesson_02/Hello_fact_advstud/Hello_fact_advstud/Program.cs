using System;

namespace Hello_fact_advstud
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Define parameters to calculate the factorial of
            //Call fact() method to calculate
            Console.WriteLine(GetFactorial(4));
        }


        private static double GetFactorial(int num)
        {
            if (num == 1 || num == 0)
                return 1;
            return num * GetFactorial(num - 1);
        }
        //Create fact() method  with parameter to calculate factorial
        //Use ternary operator

    }

    

}
