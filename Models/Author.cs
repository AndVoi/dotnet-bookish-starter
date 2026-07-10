namespace dotnet_bookish_starter.Models;

public class Author
{
    public int AuthorID { get; set; }
    public string Name { get; set; } =  string.Empty;

    public Author()
    {
        
    }
    
    public Author(int AuthorID, string Name)
    {
        this.AuthorID = AuthorID;
        this.Name = Name;
    }
}