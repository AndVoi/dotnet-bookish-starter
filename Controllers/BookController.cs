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
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Book>("SELECT * FROM Books");
        throw new NotImplementedException();
    }

    [HttpPost]
    public Book Post([FromBody] Book book)
    {
        // TODO implement the POST method
        using var connection = new SqlConnection(_connectionString);
        
        string checkCommand = String.Format("SELECT * FROM Books WHERE id = {0}", book.Id);
        if (connection.Query<Book>(checkCommand).Any())
        {
            this.HttpContext.Response.StatusCode = 403;
            return book;
        }
        
        string command = String.Format("INSERT INTO Books VALUES ({0}, \'{1}\', {2}, {3})",
            book.Id, book.Title, book.ISBN, book.copies_owned);
        connection.Query(checkCommand);
        return connection.Query<Book>(checkCommand).First();
        throw new NotImplementedException();
    }
}
