using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace ClassWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NonCls.NonCls();
            }
            catch (RuntimeWrappedException)
            {

                Console.WriteLine("NON-Cls");
            }
            catch(Exception e)
            {
                Console.WriteLine("cls compliant exception");
            }
        }
    }
}
