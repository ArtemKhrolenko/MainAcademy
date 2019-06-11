using System;
using System.Collections.Generic;

namespace Hello_Entities
{
    class Program
    {
        static void Main(string[] args)
        {
            DB_work wrk = new DB_work();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (wrk.lecturer_check())
            { Console.WriteLine("Ok");
                wrk.lecturer_find("L_1");
                wrk.lecturer_phoneUpd("L_1","123-456-78");
                wrk.lecturer_entRdr("city", "Hartford", dict);
                Console.WriteLine("Lecturers from Hartford");
                foreach (var item in dict)
                {
                    Console.WriteLine("Lecturer: {0} {1}", item.Key, item.Value);
                }
            }
            else
            { Console.WriteLine("Failure"); }
            Console.ReadKey();
        }
    }
}
