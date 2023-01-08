using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers; 

[ApiController]
[Route("[controller]")]
public class CustomerController : Controller {
    private readonly IClientRepository clientRepository;
    
    public CustomerController(IClientRepository clientRepository) {
        this.clientRepository = clientRepository;
    }

    [Authorize]
    [HttpGet("clients/all")]
    public async Task<ActionResult> getAll() {
        try {
            var clients = await clientRepository.getAll();

            if (clients.Count == 0) return StatusCode(204);
            return Ok(clients);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }

    [Authorize]
    [HttpGet("/clients/all/byFirstName")]
    public async Task<ActionResult> getAllByFirstName([FromQuery] string firstName) {
        try {
            var clients = await clientRepository.getAllByFirstName(firstName);

            if (clients.Count == 0) return StatusCode(204);
            return Ok(clients);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }
    
    [Authorize]
    [HttpGet("/clients/all/byLastName")]
    public async Task<ActionResult> getAllByLastName([FromQuery] string lastName) {
        try {
            var clients = await clientRepository.getAllByLastName(lastName);

            if (clients.Count == 0) return StatusCode(204);
            return Ok(clients);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }
    
    [Authorize]
    [HttpGet("/clients/")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var category = await clientRepository.getById(id);

            if (category == null) return NotFound();
            return Ok(category);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize("admin")]
    [HttpDelete("/clients/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            // var res = await clientRepository.deleteById(id);
            var res = await clientRepository.getById(id) != null;
    
            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/clients/delete/all")]
    public async Task<ActionResult> deleteAll() {
        try {
            // var res = await clientRepository.deleteAll();
            var res = (await clientRepository.getAll()).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/clients/delete/byFirstName")]
    public async Task<ActionResult> deleteAllByFirstName([FromQuery] string firstName) {
        try {
            // var res = await clientRepository.deleteAllByFirstName(name);
            var res = (await clientRepository.getAllByFirstName(firstName)).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/clients/delete/byLastName")]
    public async Task<ActionResult> deleteAllByLastName([FromQuery] string lastName) {
        try {
            // var res = await clientRepository.deleteAllByLastName(name);
            var res = (await clientRepository.getAllByLastName(lastName)).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpPost("/clients/create")]
    public async Task<ActionResult> create([FromBody] Customer client) {
        try {
            Console.WriteLine(client);
            var res = await clientRepository.createClient(client);

            return res != null ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("/clients/update")]
    public async Task<ActionResult> update([FromBody] Customer clientDto) {
        try {
            var res = await clientRepository.updateClient(clientDto);
            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
}