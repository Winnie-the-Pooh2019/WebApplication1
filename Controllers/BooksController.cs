using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers; 

public class BooksController : Controller {
    [HttpGet("/all")]
    public ActionResult getAllBooks() {
        return Ok();
    }
}