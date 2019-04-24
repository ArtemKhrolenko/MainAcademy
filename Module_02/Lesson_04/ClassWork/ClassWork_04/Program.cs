using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int book_pages = 365;
            Book book = new Book(book_pages);
            
            //((IPrintedBook)book).Publish();
            //((IEbook)book).Publish();

            foreach (var item in book.GetType().GetInterfaces())
            {
                Console.WriteLine(item.GetMethod("Publish").Invoke(book, null));
            }

        }
    }
}
