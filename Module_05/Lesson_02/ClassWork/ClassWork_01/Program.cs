using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_01
{
    class Distance
    {
        private decimal temp;
        public Distance (decimal distance)
        {
            this.temp = distance;
        }

        public override string ToString()
        {
            return this.temp.ToString("N1") + "km";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Distance dist = new Distance(16.30M);
            Console.WriteLine("New distance - {0}", dist.ToString());
        }
    }
}
