
Book book1 = new Book("Scott Pilgrim vs the world vI", "Bryan Lee O'Malley", "12345");
Book book2 = new Book("Moby Dick", "Herman Melville", "18390");
Book book3 = new Book("Veitemil leguas de viaje submarino", "Julio Verne", "20482");

var library = new Library();
library.AddBook(book1);
library.AddBook(book2);
library.AddBook(book3);



try
{
    library.RemoveBookByISBN();
}
catch (BookNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    library.CheckOutBookByISBN();
}
catch (BookAlreadyCheckedOutException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    library.CheckOutBookByISBN();
}
catch (BookNotCheckedOutException ex)
{
    Console.WriteLine(ex.Message);
}




public class BookNotFoundException : Exception
{
    public Library Library { get; }

    public BookNotFoundException() { }

    public BookNotFoundException(string message) : base(message)
    {

    }

}

public class BookAlreadyCheckedOutException : Exception
{
    public Library Library { get; }

    public BookAlreadyCheckedOutException() { }

    public BookAlreadyCheckedOutException(string message) : base(message)
    {

    }

}

public class BookNotCheckedOutException : Exception
{
    public Library Library { get; }

    public BookNotCheckedOutException() { }

    public BookNotCheckedOutException(string message) : base(message)
    {

    }

}




public class Book
{
    public string Author { get; }
    public string Title { get; }
    public string ISBN { get; }
    public bool IsCheckedOut { get; set; } = true;

    public Book(string title, string author, string iSBN)
    {
        Author = author;
        Title = title;
        ISBN = iSBN;
    }

    public string Details(Book book) => $"Title: {Title} \nAuthor: {Author}\n " +
        $"ISBN: {ISBN}\n Checked out: {IsCheckedOut}";

}




public class Library
{
    private List<Book> _libraryList = new List<Book>();

    //public Library() { }

    public void AddBook(Book book)
    {
        
        _libraryList.Add(book);
    }

    public void RemoveBookByISBN()
    {
        Console.WriteLine("Enter the ISBN of the book you want to remove from the library: ");
        string isbn = Console.ReadLine();

        
            foreach (Book book in _libraryList)
            {
                if (book.ISBN == isbn)
                {
                    _libraryList.Remove(book);
                    Console.WriteLine("The book has been removed");
                }
            }

        throw new BookNotFoundException("The ISBN is invalid");
       
    }

    public void CheckOutBookByISBN()
    {
        Console.WriteLine("Enter the ISBN of the book you want to remove from the library: ");
        string isbn = Console.ReadLine();

        foreach (Book book in _libraryList)
        {
            if (book.ISBN == isbn || book.IsCheckedOut == false)
                book.IsCheckedOut = true;
        }
        throw new BookAlreadyCheckedOutException("Book already checked out");
    }

    public void ReturnBookByISBN ()
    {
        Console.WriteLine("Enter the ISBN of the book you want to remove from the library: ");
        string isbn = Console.ReadLine();

        foreach (Book book in _libraryList)
        {
            if (book.ISBN == isbn || book.IsCheckedOut == true)
                book.IsCheckedOut = false;
        }
        throw new BookNotCheckedOutException("Book already checked out");
    }

    public void DisplayAllBooks()
    {
        foreach (Book book in _libraryList)
        {
            var details = book.Details(book);
            Console.WriteLine(details);
        }
    }
}
