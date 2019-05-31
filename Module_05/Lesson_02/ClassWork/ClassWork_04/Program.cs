using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Threading.Tasks;

namespace ClassWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            MatchCollection matches;
            List<string> results = new List<string>();
            List<int> matchPositions = new List<int>();

            Regex r = new Regex("Text");
            matches = r.Matches("There is Text about regular expression. Text include several words \"Text\"");

            foreach (Match match in matches)
            {
                results.Add(match.Value);
                matchPositions.Add(match.Index);

            }

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"'{results[i]}' found at position {matchPositions[i]}");
            }

            
        }
    }
}
