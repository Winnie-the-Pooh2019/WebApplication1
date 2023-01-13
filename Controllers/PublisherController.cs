using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers; 

[ApiController]
[Route("[controller]")]
public class PublisherController : Controller {
    private readonly IPublisherRepository publisherRepository;

    public PublisherController(IPublisherRepository publisherRepository) {
        this.publisherRepository = publisherRepository;
    }
    
    [Authorize]
    [HttpGet("/publisher/all")]
    public async Task<ActionResult> getAll() {
        try {
            var categories = await publisherRepository.getAll();

            if (categories.Count == 0) return StatusCode(204);
            return Ok(categories);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound("No Categories found");
        }
    }
    
    [Authorize]
    [HttpGet("/publisher/all/byName")]
    public async Task<ActionResult> getAllByName([FromQuery] string name) {
        try {
            var categories = await publisherRepository.getAllByName(name);

            if (categories.Count == 0) return StatusCode(204);
            return Ok(categories);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }
    
    [Authorize]
    [HttpGet("/publisher/")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var category = await publisherRepository.getById(id);

            if (category == null) return NotFound("Publisher with such id doesnt exists");
            return Ok(category);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/publisher/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            var res = await publisherRepository.deleteById(id);
            // var res = await publisherRepository.getById(id) != null;
    
            return res ? Ok() : StatusCode(500, "Publisher with such id doesnt exists");
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/publisher/delete/all")]
    public async Task<ActionResult> deleteAll() {
        try {
            var res = await publisherRepository.deleteAll();
            // var res = (await publisherRepository.getAll()).Count != 0;

            return res ? Ok() : StatusCode(500, "No publishers found");
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/publisher/delete/byName")]
    public async Task<ActionResult> deleteAllByName([FromQuery] string name) {
        try {
            var res = await publisherRepository.deleteAllByName(name);
            // var res = (await publisherRepository.getAllByName(name)).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpPost("/publisher/create")]
    public async Task<ActionResult> create([FromBody] Publisher category) {
        try {
            Console.WriteLine(category);
            var res = await publisherRepository.createPublisher(category);

            return res != null ? Ok() : StatusCode(500, "Such publisher already exists");
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("/publisher/update")]
    public async Task<ActionResult> update([FromBody] Publisher categoryDto) {
        try {
            var res = await publisherRepository.updatePublisher(categoryDto);
            return res ? Ok() : StatusCode(500, "No publisher with such id found");
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }
}