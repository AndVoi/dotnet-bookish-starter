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
    public Book Post([FromBody] Book book)
    {
        // TODO implement the POST method
        throw new NotImplementedException();
    }
}
