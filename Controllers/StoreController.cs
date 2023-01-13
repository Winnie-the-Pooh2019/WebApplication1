using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers; 

[ApiController]
[Route("[controller]")]
public class StoreController : Controller {
    private readonly IStoreRepository storeRepository;

    public StoreController(IStoreRepository storeRepository) {
        this.storeRepository = storeRepository;
    }

    [Authorize]
    [HttpGet("/store/all")]
    public async Task<ActionResult> getAll() {
        try {
            var stores = await storeRepository.getAll();

            if (stores.Count == 0) return StatusCode(204);
            return Ok(stores);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound("No Store found");
        }
    }

    [Authorize]
    [HttpGet("/store/byId")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var store = await storeRepository.getById(id);

            if (store == null) return NotFound("No store with such id exists");
            return Ok(store);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/store/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            var res = await storeRepository.getById(id) != null;
            // var res = await storeRepository.getById(id) != null;

            return res ? Ok() : StatusCode(500, "No store found");
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/store/delete/all")]
    public async Task<ActionResult> deleteAll() {
        try {
            var res = await storeRepository.deleteAll();
            // var res = (await storeRepository.getAll()).Count != 0;

            return res ? Ok() : StatusCode(500, "No stores found");
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPost("/store/create")]
    public async Task<ActionResult> create([FromBody] Store store) {
        try {
            Console.WriteLine(store);
            var res = await storeRepository.createStore(store);

            return res != null ? Ok() : StatusCode(500, "Store with such id exists");
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPut("/store/update")]
    public async Task<ActionResult> update([FromBody] Store store) {
        try {
            Console.WriteLine(store);
            var res = await storeRepository.updateStore(store);

            return res ? Ok() : StatusCode(500, "No store with such id found");
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }
}