using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassWork_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = { "000-111-22-33", "00-111-22-33"};
            string pattern = @"^\d{3}-\d{3}-\d{2}-\d{2}$";
            foreach (var value in values)
            {
                if(Regex.IsMatch(value, pattern))
                    Console.WriteLine($"{value} is a valid phone number");
                else
                    Console.WriteLine($"{value} : invalid");
            }

            string input = "There is is some text about about regular expression";
            pattern = @"\b(\w+)\W+(\1)\b";
            foreach (Match match in Regex.Matches(input, pattern))               
            {
                Console.WriteLine("Duplicate '{0}' found at position {1}.",
                //match.Groups[1].Value, match.Groups[2].Index);
                match.Groups[1].Value, match.Groups[2].Index);

                
            }
        }
    }
}
