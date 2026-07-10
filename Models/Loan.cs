namespace dotnet_bookish_starter.Models;

public class Loan
{
    public int LoanID { get; set; }
    public int BookID { get; set; }
    public int UserID { get; set; }
    public DateOnly LoanDate { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly? ReturnDate { get; set; }

    public Loan()
    {
        
    }

    public Loan(int LoanID, int BookID, int UserID, DateOnly LoanDate, DateOnly DueDate)
    {
        this.LoanID = LoanID;
        this.BookID = BookID;
        this.UserID = UserID;
        this.LoanDate = LoanDate;
        this.DueDate = DueDate;
    }
    
}