using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Persistence;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public AuthorsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpPost]
    public ActionResult CreateAuthor(Author author)
    {
        try
        {
            _dbContext.Authors?.Add(author);
            _dbContext.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}