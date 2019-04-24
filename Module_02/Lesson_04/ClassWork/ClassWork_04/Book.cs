using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_04
{
    class Book : IPrintedBook, IEbook
    {
        public int Pages { get; private set;}
        public Book(int pages)
        {
            this.Pages = pages;
        }
        void IPrintedBook.Publish()
        {
            Console.WriteLine("Book is printing...");
            
        }

        void IEbook.Publish()
        {
            Console.WriteLine("Book is uploading...");
            
        }

       
        //public void Publish()
        //{
        //    Console.WriteLine("Book is publishing...");
        //}

        
    }
}
