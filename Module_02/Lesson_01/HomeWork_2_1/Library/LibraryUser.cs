using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class LibraryUser : ILibraryUser
    {

        #region Props
        internal string FirstName { get; }
        internal string LastName { get; }
        internal int Id { get; }
        internal string Phone { get; set; }
        internal int BookLimit { get; }
        #endregion
        
        
        #region Fields
        private string[] bookList;
        internal string this[int i]
        {            
            get
            {
                if (i < 0 || i > BookLimit - 1)
                {
                    Console.WriteLine($"Incorrect indexer. Book limit for current user = {BookLimit}");
                    return null;
                }                    
                else
                    return bookList[i];
            }
            set
            {
                if (value == "" )
                    Console.WriteLine("Empty Book name. Enter the book Name!");
                else if (i < 0 || i > BookLimit - 1)
                    Console.WriteLine($"Incorrect indexer. Book limit for current user = {BookLimit}");
                else
                    bookList[i] = value;                
            }
        }
                
        #endregion

        #region Constructors
        public LibraryUser()
        {
            
        }
        public LibraryUser(string firstName, string lastName, int id, string phone, int bookLimit) 
        {
            bookList = new string[bookLimit]; //Creating string array for books

            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Phone = phone;
            BookLimit = bookLimit;
        }

        #endregion

        #region Methods
        public void AddBook(string bookName)
        {
            if (bookList.Contains(bookName))
            {
                Console.WriteLine($"The book \"{bookName}\" is already in a list!");
                return;
            }

            for (int i = 0; i < bookList.Length; i++)
            {                
                if (bookList[i] == null)
                {
                    bookList[i] = bookName;
                    return;
                }
            }
        }

        public void RemoveBook(string bookName)
        {
            for (int i = 0; i < bookList.Length; i++)
            {
                if (!bookList.Contains(bookName))
                {
                    Console.WriteLine($"There is no book with Name \"{bookName}\" in a list!");
                    return;
                }
                if (bookList[i] == bookName)
                {
                    bookList[i] = null;
                    return;
                }
            }
        }

        public string BookInfo(int index)
        {
            return $"Book name: {this[index]}";            
        }

        public int BooksCount()
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
