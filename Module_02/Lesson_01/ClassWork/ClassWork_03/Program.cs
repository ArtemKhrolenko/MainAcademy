using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ClassWork_03
{
    class Employee
    {
        public static int EmpCount;
        public string FirstNasme;
        public string LastName;
        public string rank;

        public Employee(string first, string last, string rank)
        {
            FirstNasme = first;
            LastName = last;
            this.rank = rank;
        }

        public Employee()
        {

        }

    }
    class Program
    {
        private void Method()
        {
            SomeClass sc = new SomeClass();
            
        }
        static void Main(string[] args)
        {
            Employee p = new Employee("Valery", "Lode", "first");

            Console.WriteLine("First name = " + p.FirstNasme + " Last Name = " + p.LastName + " rank = " + p.rank);
        }

        
        
    }
}
