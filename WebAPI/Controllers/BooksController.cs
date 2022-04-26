using Domain;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Persistence;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BooksController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public BooksController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult CreateBook(Book book)
    {
        try
        {
            _dbContext.Books?.Add(book);
            _dbContext.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


    [HttpGet("{id:int}")]
    public ActionResult<Book> GetBookById([FromRoute] int id)
    {
        var book = _dbContext.Books?.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }
}