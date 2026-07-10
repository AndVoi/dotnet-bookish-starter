namespace dotnet_bookish_starter.Models;

public class Book
{
    public int BookID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty; 
    public int NumberOfCopies { get; set; }

    public Book()
    {
        
    }

    public Book(int BookID, string Title, string ISBN, int NumberOfCopies)
    {
        this.BookID = BookID;
        this.Title = Title;
        this.ISBN = ISBN;
        this.NumberOfCopies = NumberOfCopies;
    }
}
