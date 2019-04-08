using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryUser user = new LibraryUser("Artem", "Khrolenko", 18, "0662655434", 10);
           
            

            Console.WriteLine(user.BookInfo(10));

            
        }
    }
}
