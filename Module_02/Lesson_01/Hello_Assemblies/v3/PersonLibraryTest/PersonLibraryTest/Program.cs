using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLibrary;

namespace PersonLibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Person student = new Person();
            student.FirstName = "Andy";
            student.LastName = "Sharp";
            student.Birthday = new DateTime(1995, 3, 15);
            Console.WriteLine("Student info: " + student.FirstName + " " + student.LastName + ", birthday " + student.Birthday.ToString("dddd, d MMM, yyyy at HH:mm"));
        }
    }
}
