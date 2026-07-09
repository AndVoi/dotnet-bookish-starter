using dotnet_bookish_starter.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;

namespace dotnet_bookish_starter.Controllers;

[ApiController]
[Route("book")]
public class BookController : ControllerBase
{
    private readonly string _connectionString;
 
    public BookController(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DbConnectionString") ?? "";
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> Get()
    {
        // TODO implement the GET method
        await using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Book>("SELECT * FROM Books");
        //throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book book)
    {
        // TODO implement the POST method
        await using var connection = new SqlConnection(_connectionString);
        string sql = @"
            INSERT INTO dbo.Books (BookID, Title, ISBN, NumberOfCopies)
            VALUES (@BookID, @Title, @ISBN, @NumberOfCopies);";
        
        connection.ExecuteAsync(sql, book);
        
        //await throw new NotImplementedException();
        return CreatedAtAction(nameof(Get), new { id = book.BookID }, book);
    }
}
