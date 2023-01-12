using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers; 

[ApiController]
[Route("[controller]")]
public class PurchaseItemController : Controller {
    private readonly IPurchaseItemRepository purchaseItemRepository;

    public PurchaseItemController(IPurchaseItemRepository purchaseItemRepository) {
        this.purchaseItemRepository = purchaseItemRepository;
    }

    [Authorize]
    [HttpGet("/purchaseItem/all")]
    public async Task<ActionResult> getAll() {
        try {
            var purchaseItems = await purchaseItemRepository.getAll();

            if (purchaseItems.Count == 0) return StatusCode(204);
            return Ok(purchaseItems);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound();
        }
    }

    [Authorize]
    [HttpGet("/purchaseItem/all/byPurchaseId")]
    public async Task<ActionResult> getAllByPurchaseId([FromQuery] int purchaseId) {
        try {
            var purchaseItems = await purchaseItemRepository.getAllByPurchaseId(purchaseId);

            if (purchaseItems.Count == 0) return StatusCode(204);
            return Ok(purchaseItems);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound();
        }
    }
    
    [Authorize]
    [HttpGet("/purchaseItem/all/byBookId")]
    public async Task<ActionResult> getAllByBookId([FromQuery] int bookId) {
        try {
            var purchaseItems = await purchaseItemRepository.getAllByBookId(bookId);

            if (purchaseItems.Count == 0) return StatusCode(204);
            return Ok(purchaseItems);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound();
        }
    }
    
    [Authorize]
    [HttpGet("/purchaseItem/")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var purchaseItems = await purchaseItemRepository.getById(id);

            if (purchaseItems == null) return NotFound();
            return Ok(purchaseItems);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound();
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/purchaseItem/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            // var res = await purchaseItemRepository.deleteById(id);
            var res = (await purchaseItemRepository.getById(id)) != null;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/purchaseItem/delete/byPurchaseId")]
    public async Task<ActionResult> deleteByPurchaseId([FromQuery] int purchaseId) {
        try {
            // var res = await purchaseItemRepository.deleteAllByPurchaseId(purchaseId);
            var res = (await purchaseItemRepository.getAllByPurchaseId(purchaseId)).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/purchaseItem/delete/byBookId")]
    public async Task<ActionResult> deleteByBookId([FromQuery] int bookId) {
        try {
            // var res = await purchaseItemRepository.deleteAllByBookId(bookId);
            var res = (await purchaseItemRepository.getAllByBookId(bookId)).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("/purchaseItem/delete/all")]
    public async Task<ActionResult> deleteAll() {
        try {
            // var res = await purchaseItemRepository.deleteAll();
            var res = (await purchaseItemRepository.getAll()).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPost("/purchaseItem/create")]
    public async Task<ActionResult> create([FromBody] PurchaseItem item) {
        try {
            var res = await purchaseItemRepository.createPurchaseItem(item);

            return res != null ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("/purchaseItem/update")]
    public async Task<ActionResult> update([FromBody] PurchaseItem item) {
        try {
            var res = await purchaseItemRepository.updatePurchaseItem(item);

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }
}