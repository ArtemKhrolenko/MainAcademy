using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string str_a = Console.ReadLine();
            try
            {
                int b = (int)uint.Parse(str_a);
            }
            catch(FormatException)
            {
                Console.WriteLine($"You entered an icorrect number {str_a}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
