using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers; 

[ApiController]
[Route("[controller]")]
public class PurchaseController : Controller {
    private readonly IPurchaseRepository purchaseRepository;

    public PurchaseController(IPurchaseRepository purchaseRepository) {
        this.purchaseRepository = purchaseRepository;
    }

    [Authorize]
    [HttpGet("/purchase/all")]
    public async Task<ActionResult> getAll() {
        try {
            var purchases = await purchaseRepository.getAll();

            if (purchases.Count == 0) return StatusCode(204);
            return Ok(purchases);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }

    [Authorize]
    [HttpGet("/purchase/all/byCustomerId")]
    public async Task<ActionResult> getAllByCustomerId([FromQuery] int id) {
        try {
            var purchases = await purchaseRepository.getAllByCustomerId(id);

            if (purchases.Count == 0) return StatusCode(204);
            return Ok(purchases);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound();
        }
    }
    
    [Authorize]
    [HttpGet("/purchase/all/byDate")]
    public async Task<ActionResult> getAllByCustomerId([FromQuery] string date) {
        try {
            var purchases = await purchaseRepository.getAllByDate(Convert.ToDateTime(date));

            if (purchases.Count == 0) return StatusCode(204);
            return Ok(purchases);
        }
        catch (FormatException e) {
            Console.WriteLine(e.StackTrace);
            return BadRequest();
        } 
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound();
        }
    }

    [Authorize]
    [HttpGet("/purchase/")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var purchase = await purchaseRepository.getById(id);

            if (purchase == null) return NotFound();
            return Ok(purchase);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/purchase/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            // var res = await purchaseRepository.deleteById(id);
            var res = await purchaseRepository.getById(id) != null;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/purchase/delete/all")]
    public async Task<ActionResult> deleteAll() {
        try {
            // var res = await purchaseRepository.deleteById(id);
            var res = (await purchaseRepository.getAll()).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/purchase/delete/all/byCustomerId")]
    public async Task<ActionResult> deleteAllByCustomerId([FromQuery] int id) {
        try {
            // var res = await purchaseRepository.deleteById(id);
            var res = (await purchaseRepository.getAllByCustomerId(id)).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/purchase/delete/all/byDate")]
    public async Task<ActionResult> deleteAllByDate([FromQuery] string date) {
        try {
            // var res = await purchaseRepository.deleteById(id);
            var res = (await purchaseRepository.getAllByDate(Convert.ToDateTime(date))).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (FormatException e) {
            Console.WriteLine(e.StackTrace);
            return BadRequest();
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPost("/purchase/create")]
    public async Task<ActionResult> create([FromBody] Purchase purchase) {
        try {
            Console.WriteLine(purchase);
            var res = await purchaseRepository.createPurchase(purchase);

            return res != null ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("/purchase/update")]
    public async Task<ActionResult> update([FromBody] Purchase purchase) {
        try {
            Console.WriteLine(purchase);
            var res = await purchaseRepository.updatePurchase(purchase);

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
}