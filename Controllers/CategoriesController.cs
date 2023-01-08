using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers; 

[ApiController]
[Route("[controller]")]
public class CategoriesController : Controller {
    private readonly ICategoryRepository categoryRepository;
    
    public CategoriesController(ICategoryRepository categoryRepository) {
        this.categoryRepository = categoryRepository;
    }

    [Authorize]
    [HttpGet("/categories/all")]
    public async Task<ActionResult> getAll() {
        try {
            var categories = await categoryRepository.getAll();

            if (categories.Count == 0) return StatusCode(204);
            return Ok(categories);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }
    
    [Authorize]
    [HttpGet("/categories/all/byName")]
    public async Task<ActionResult> getAllByName([FromQuery] string name) {
        try {
            var categories = await categoryRepository.getAllByName(name);

            if (categories.Count == 0) return StatusCode(204);
            return Ok(categories);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }
    
    [Authorize]
    [HttpGet("/categories/")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var category = await categoryRepository.getById(id);

            if (category == null) return NotFound();
            return Ok(category);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/categories/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            var res = await categoryRepository.deleteById(id);
            // var res = await categoryRepository.getById(id) != null;
    
            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/categories/delete/all")]
    public async Task<ActionResult> deleteAll() {
        try {
            // var res = await categoryRepository.deleteAll();
            var res = (await categoryRepository.getAll()).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/categories/delete/byName")]
    public async Task<ActionResult> deleteAllByName([FromQuery] string name) {
        try {
            // var res = await categoryRepository.deleteAllByName(name);
            var res = (await categoryRepository.getAllByName(name)).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpPost("/categories/create")]
    public async Task<ActionResult> create([FromBody] Category category) {
        try {
            Console.WriteLine(category);
            var res = await categoryRepository.create(category);

            return res != null ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("/categories/update")]
    public async Task<ActionResult> update([FromBody] Category categoryDto) {
        try {
            var res = await categoryRepository.updateCategory(categoryDto);
            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
}