namespace dotnet_bookish_starter.Models;

public class Book
{
    // TODO add the relevant properties
    public int BookID { get; set; }
    public string Title { get; set; } = string.Empty;
    public long ISBN { get; set; } 
    public int NumberOfCopies { get; set; }

    public Book()
    {
        
    }

    public Book(int BookID, string Title, long ISBN, int NumberOfCopies)
    {
        this.BookID = BookID;
        this.Title = Title;
        this.ISBN = ISBN;
        this.NumberOfCopies = NumberOfCopies;
    }
}
