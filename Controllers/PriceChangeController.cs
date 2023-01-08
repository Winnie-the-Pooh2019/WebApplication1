using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceChangeController : Controller {
    private readonly IPriceChangeRepository priceChangeRepository;

    public PriceChangeController(IPriceChangeRepository priceChangeRepository) {
        this.priceChangeRepository = priceChangeRepository;
    }

    [Authorize]
    [HttpGet("/price/all")]
    public async Task<ActionResult> getAll() {
        try {
            var prices = await priceChangeRepository.getAll();

            if (prices.Count == 0) return StatusCode(204);
            return Ok(prices);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }

    [Authorize]
    [HttpGet("/price/all/byDate")]
    public async Task<ActionResult> getAllByDate([FromQuery] string date) {
        try {
            var prices = await priceChangeRepository.getAllByDate(Convert.ToDateTime(date));

            if (prices.Count == 0) return StatusCode(204);
            return Ok(prices);
        }
        catch (FormatException e) {
            Console.WriteLine(e.StackTrace);
            return BadRequest(e.StackTrace);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }

    [Authorize]
    [HttpGet("/price/byId")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var price = await priceChangeRepository.getById(id);

            if (price == null) return NotFound();
            return Ok(price);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/price/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            // var price = await priceChangeRepository.deleteById(id);
            var price = await priceChangeRepository.getById(id) != null;

            return price ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/price/delete/all")]
    public async Task<ActionResult> deleteAll() {
        try {
            // var price = await priceChangeRepository.deleteAll();
            var price = (await priceChangeRepository.getAll()).Count != 0;

            return price ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/price/delete/all/byDate")]
    public async Task<ActionResult> deleteAllByDate([FromQuery] string date) {
        try {
            // var price = await priceChangeRepository.deleteAllByDate(Convert.ToDateTime(date));
            var price = (await priceChangeRepository.getAllByDate(Convert.ToDateTime(date))).Count != 0;

            return price ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPost("/price/create/")]
    public async Task<ActionResult> create([FromBody] PriceChange priceChange) {
        try {
            Console.WriteLine(priceChange);
            var res = await priceChangeRepository.createPriceChange(priceChange);

            return res != null ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPut("/price/update")]
    public async Task<ActionResult> update([FromBody] PriceChange priceChange) {
        try {
            var res = await priceChangeRepository.updatePriceChange(priceChange);
            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
}