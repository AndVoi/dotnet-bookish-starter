using dotnet_bookish_starter.Models;
using dotnet_bookish_starter.Dtos;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;

namespace dotnet_bookish_starter.Controllers;

[ApiController]
[Route("books")] // url-ul de baza este http://localhost:5159/books
public class BookController : ControllerBase
{ 
    private readonly string _connectionString;
    public BookController(IConfiguration config)
    {
         _connectionString = config.GetConnectionString("DbConnectionString") ?? "";
    }

    [HttpGet]
    public async Task<IActionResult> getBooks([FromQuery] string? title, [FromQuery] string? author)
    {
        //Console.WriteLine(author);
        await using var connection = new SqlConnection(_connectionString);
        string sqlCommand;
        
        if (!string.IsNullOrEmpty(author))
        {
            sqlCommand = @"SELECT b.* FROM dbo.Books b
                JOIN dbo.BooksAuthors ba ON b.BookID = ba.BookID
                JOIN dbo.Authors a ON ba.AuthorID = a.AuthorID
                WHERE a.Name LIKE @AuthorName
                ORDER BY b.Title ASC";
            
            var booksByAuthor = await connection.QueryAsync<Book>(sqlCommand, new { AuthorName = "%" + author + "%" });
            return Ok(booksByAuthor);
        }
        
        if (!string.IsNullOrEmpty(title))
        {
            sqlCommand = "SELECT * FROM dbo.Books WHERE Title LIKE @Title ORDER BY Title ASC";
            var booksByTitle = await connection.QueryAsync<Book>(sqlCommand, new { Title = "%" + title + "%" });
            return Ok(booksByTitle);
        }
        
        sqlCommand = "SELECT * FROM dbo.Books ORDER BY Title ASC";
        var allBooks = await connection.QueryAsync<Book>(sqlCommand);
        return Ok(allBooks);
    }

    [HttpGet("{id}/availability")]
    public async Task<IActionResult> getBookAvailability(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        
        string bookSql = "SELECT NumberOfCopies FROM dbo.Books WHERE BookID = @BookID";
        
        int totalCopies = await connection.QueryFirstOrDefaultAsync<int>(bookSql, new { BookID = id });
        
        string loansSql = @"
            SELECT u.Name AS UserName, l.DueDate 
            FROM dbo.Loans l
            JOIN dbo.Users u ON l.UserID = u.UserID
            WHERE l.BookID = @BookID AND l.ReturnDate IS NULL";
        
        var activeLoans = (await connection.QueryAsync<BorrowerDetailsDTO>(loansSql, new { BookID = id })).ToList();
        
        int availableCopies = totalCopies - activeLoans.Count;
        
        var availability = new BookAvailabilityDTO
        {
            TotalCopies = totalCopies,
            AvailableCopies = availableCopies,
            BorrowedBy = activeLoans
        };
        
        return Ok(availability);
    }
    
    [HttpPost]
    public async Task<IActionResult> addBook([FromBody] BookCreateDTO body)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        
        await using var transaction = await connection.BeginTransactionAsync();

        try
        {
            string insertBookSql = @"
                INSERT INTO dbo.Books (Title, ISBN, NumberOfCopies)
                VALUES (@Title, @ISBN, @NumberOfCopies);
                SELECT CAST(SCOPE_IDENTITY() as int);";
            
            int newBookId = await connection.QuerySingleAsync<int>(insertBookSql, body, transaction);
            
            if (body.AuthorIds != null && body.AuthorIds.Any())
            {
                string insertRelationSql = "INSERT INTO dbo.BooksAuthors (BookID, AuthorID) VALUES (@BookID, @AuthorID);";
                
                foreach (var authorId in body.AuthorIds)
                {
                    await connection.ExecuteAsync(insertRelationSql, new { BookID = newBookId, AuthorID = authorId }, transaction);
                }
            }
            
            await transaction.CommitAsync();
            return StatusCode(201, new { message = "s-a adaugat cartea", bookId = newBookId });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, $"nu s-a putut adauga cartea: {ex.Message}");
        }
    }
    
    [Microsoft.AspNetCore.Mvc.HttpPatch("{id}")]
    public async Task<IActionResult> modifyBook(int id, [FromBody] BookUpdateDTO body)
    {
        await using var connection = new SqlConnection(_connectionString);
        
        string sql = @"
            UPDATE dbo.Books 
            SET Title = @Title, ISBN = @ISBN, NumberOfCopies = @NumberOfCopies
            WHERE BookID = @BookID";
        
        int rowsAffected = await connection.ExecuteAsync(sql, new { 
            Title = body.Title, 
            ISBN = body.ISBN, 
            NumberOfCopies = body.NumberOfCopies, 
            BookID = id 
        });

        if (rowsAffected == 0)
            return NotFound($"cartea cu ID-ul {id} nu a fost gasita");

        return Ok(new { message = $"cartea cu ID-ul {id} a fost modificata" });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteBook(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        
        string sql = "DELETE FROM dbo.Books WHERE BookID = @BookID";
        
        int rowsAffected = await connection.ExecuteAsync(sql, new { BookID = id });

        if (rowsAffected == 0)
            return NotFound($"cartea cu ID-ul {id} nu exista");

        return Ok(new { message = $"cartea cu ID-ul {id} a fost stearsa" });
    }
}