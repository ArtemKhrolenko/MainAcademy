using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;





namespace BirdSpeciesLibrary
{

    class Program
    {
        static void Main(string[] args)
        {
            Type t = new Program().GetType();
            t.GetCustomAttribute(Program.get);
        }
    }
}
