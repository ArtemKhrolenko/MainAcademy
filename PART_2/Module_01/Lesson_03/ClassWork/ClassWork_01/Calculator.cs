using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    public static class Calculator
    {
        public static double Add (double arg1, double arg2)
        {
            return (arg1 + arg2);
        }

        public static double Sub(double arg1, double arg2)
        {
            return (arg1 - arg2);
        }

        public static double Mult(double arg1, double arg2)
        {
            return (arg1 * arg2);
        }

        // Example 2 - code coverage with exception
        public static double Div(double arg1, double arg2)
        {
            if (arg2 == 0.0)
                throw new ArgumentException("Argument equals zero");
            return (arg1 / arg2);
        }
    }
}
