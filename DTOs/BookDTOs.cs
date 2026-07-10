namespace dotnet_bookish_starter.Dtos;

public class BookCreateDTO
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty; 
    public int NumberOfCopies { get; set; }
    public List<int> AuthorIds { get; set; } = new();
}

public class BookUpdateDTO
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int NumberOfCopies { get; set; }
    public List<int> AuthorIds { get; set; } = new();
}

public class BorrowerDetailsDTO
{
    public string UserName { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
}

public class BookAvailabilityDTO
{
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public List<BorrowerDetailsDTO> BorrowedBy { get; set; } = new();
}