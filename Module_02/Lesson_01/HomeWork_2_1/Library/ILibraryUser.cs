using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface ILibraryUser
    {
        void AddBook(string bookName);
        void RemoveBook(string bookName);
        string BookInfo(int index);
        int BooksCount();


    }
}
