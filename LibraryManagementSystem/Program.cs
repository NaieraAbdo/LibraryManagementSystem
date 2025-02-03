namespace LibraryManagementSystem
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, string isbn, bool isAvailable = true)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = isAvailable;
        }
    }

    class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }

        public  void PrintBooksDetails(Library library)
        {
            foreach (var book in library.Books)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Is available: {book.IsAvailable}");
                Console.WriteLine($"ISBN: {book.ISBN}");
                Console.WriteLine($"------------------------------");
            }
        }
        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public bool SearchBook(string Searchtool)
        {
            foreach (var book in Books)
            {
                if (book.Title.Contains(Searchtool) || book.Author.Contains(Searchtool))
                {
                    return true;
                }
            }
            return false;
        }

        public void BorrowBook(string Searchtool)
        {
            bool isavailable = SearchBook(Searchtool);
            if (isavailable)
            {

                foreach (var book in Books)
                {
                    if (book.Title.Contains(Searchtool)|| book.Author.Contains(Searchtool))
                    {
                        book.IsAvailable = false;
                    }
                }
            }
            else
                Console.WriteLine($"-------This book {Searchtool} doesn't exist.----------");
        }

        public void ReturnBook(string Searchtool)
        {
            bool isavailable = SearchBook(Searchtool);
            if (isavailable)
            {
                foreach (var book in Books)
                {
                    if (book.Title.Contains(Searchtool) || book.Author.Contains(Searchtool))
                    {
                        book.IsAvailable = true;
                    }
                }
            }
            else
                Console.WriteLine($"--------This book {Searchtool} doesn't exist.----------");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            library.PrintBooksDetails(library);

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            Console.WriteLine("---------------------------");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            library.PrintBooksDetails(library);


            // Returning books
            Console.WriteLine("\nReturning books...");
            Console.WriteLine("---------------------------");
            library.ReturnBook("1984");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            library.PrintBooksDetails(library);


        }
    }
}