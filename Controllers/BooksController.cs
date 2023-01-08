using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : Controller {
    private readonly IBookRepository bookRepository;

    public BooksController(IBookRepository bookRepository) {
        this.bookRepository = bookRepository;
    }

    [Authorize]
    [HttpGet("/books/all")]
    public async Task<ActionResult> getAllBooks() {
        try {
            var books = await bookRepository.getAll();

            if (books.Count == 0) return StatusCode(204);
            return Ok(books);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound("Unable to connect to database");
        }
    }

    [Authorize]
    [HttpGet("/books/all/byName")]
    public async Task<ActionResult> getAllByByName([FromQuery] string name) {
        try {
            var books = await bookRepository.getAllByName(name);

            if (books.Count == 0) return StatusCode(204);
            return Ok(books);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound("Unable to connect to database");
        }
    }

    [Authorize]
    [HttpGet("/books/all/byPublisherId")]
    public async Task<ActionResult> getAllByPublisherId([FromQuery] int publisherId) {
        try {
            var books = await bookRepository.getAllByPublisherId(publisherId);

            if (books.Count == 0) return StatusCode(204);
            return Ok(books);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound("Unable to connect to database");
        }
    }

    [Authorize]
    [HttpGet("/books/all/byCategoryId")]
    public async Task<ActionResult> getAllByCategoryId([FromQuery] int categoryId) {
        try {
            var books = await bookRepository.getAllByCategoryId(categoryId);

            if (books.Count == 0) return StatusCode(204);
            return Ok(books);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound("Unable to connect to database");
        }
    }

    [Authorize]
    [HttpGet("/books/")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var book = await bookRepository.getById(id);

            if (book == null)
                return NotFound("No books find with such id");

            return Ok(book);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500);
        }
    }

    [Authorize("admin")]
    [HttpDelete("/books/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            // var res = await bookRepository.deleteById(id);
            var res = await bookRepository.getById(id) != null;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/books/delete/byName")]
    public async Task<ActionResult> deleteAllByName([FromQuery] string name) {
        try {
            // var res = await bookRepository.deleteAllByName(name);
            var res = (await bookRepository.getAllByName(name)).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/books/delete/all")]
    public async Task<ActionResult> deleteAll() {
        try {
            // var res = await bookRepository.deleteAll();
            var res = (await bookRepository.getAll()).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPost("/books/create")]
    public async Task<ActionResult> create([FromBody] Book bookDto) {
        try {
            // var catRes = await categoryRepository.getById(bookDto.categoryId) ??
            //              await categoryRepository.create(bookDto.category);
            //
            // var pubRes = await publisherRepository.getById(bookDto.publisherId) ??
            //              await publisherRepository.createPublisher(bookDto.publisher);
            //
            // if (pubRes != null) {
            //     bookDto.publisher = pubRes;
            //     bookDto.publisherId = pubRes.id;
            // }
            //
            // if (catRes != null) {
            //     bookDto.category = catRes;
            //     bookDto.categoryId = catRes.id;
            // }

            Console.WriteLine(bookDto);
            var res = await bookRepository.createBook(bookDto);

            return res != null ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPut("/books/update")]
    public async Task<ActionResult> update([FromBody] Book bookDto) {
        try {
            // var catRes = await categoryRepository.getById(bookDto.category.id) ??
            //              await categoryRepository.create(bookDto.category);
            //
            // var pubRes = await publisherRepository.getById(bookDto.publisher.id) ??
            //              await publisherRepository.createPublisher(bookDto.publisher);
            //
            // if (pubRes != null) {
            //     bookDto.publisher = pubRes;
            //     bookDto.publisherId = pubRes.id;
            // }
            //
            // if (catRes != null) {
            //     bookDto.category = catRes;
            //     bookDto.categoryId = catRes.id;
            // }

            Console.WriteLine(bookDto);

            var res = await bookRepository.updateBook(bookDto);
            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
}