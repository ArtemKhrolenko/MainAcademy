using System;
using System.Linq;
namespace CSharp_Net_module1_2_1_lab
{
    interface ILibraryUser
    {
        void AddBook(string bookName);
        void RemoveBook(string bookName);
        string BookInfo(int index);
        int BooksCount();
    }


    // 2) declare class LibraryUser, it implements ILibraryUser
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
        // 3) declare properties: FirstName (read only), LastName (read only), 
        // Id (read only), Phone (get and set), BookLimit (read only)
        // 4) declare field (bookList) as a string array
        private static int userCount;

        private string[] bookList;

        // 5) declare indexer BookList for array bookList
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
        // 6) declare constructors: default and parameter
        public LibraryUser()
        {
            Id = ++userCount;
            bookList = new string[BookLimit + 1]; //Creating string array for books
        }
        public LibraryUser(string firstName, string lastName, string phone, int bookLimit) : this()
        {           

            FirstName = firstName;
            LastName = lastName;            
            Phone = phone;
            BookLimit = bookLimit;
            
        }

        #endregion

        #region Methods
        // 7) declare methods: 

        //AddBook() – add new book to array bookList
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


        //RemoveBook() – remove book from array bookList
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

        //BookInfo() – returns book info by index
        public string BookInfo(int index)
        {
            return $"Book name: {this[index]}";            
        }

        //BooksCout() – returns current count of books
        public int BooksCount()
        {
            throw new NotImplementedException();
        }
        #endregion

    }

}
