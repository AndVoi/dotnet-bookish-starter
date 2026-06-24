using dotnet_bookish_starter.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_bookish_starter.Controllers;

[ApiController]
[Route("book")]
public class BookController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Book> Get()
    {
        // TODO implement the GET method
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public Book Post([FromBody] Book book)
    {
        // TODO implement the POST method
        throw new NotImplementedException();
    }
}
