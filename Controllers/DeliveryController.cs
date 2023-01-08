using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveryController : Controller {
    private readonly IDeliveryRepository deliveryRepository;

    public DeliveryController(IDeliveryRepository deliveryRepository) {
        this.deliveryRepository = deliveryRepository;
    }

    [Authorize]
    [HttpGet("/delivery/all")]
    public async Task<ActionResult> getAll() {
        try {
            var deliveries = await deliveryRepository.getAll();

            if (deliveries.Count == 0) return StatusCode(204);
            return Ok(deliveries);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }

    [Authorize]
    [HttpGet("/delivery/all/byBookId")]
    public async Task<ActionResult> getAllByBookId([FromQuery] int bookId) {
        try {
            var deliveries = await deliveryRepository.getAllByBookId(bookId);

            if (deliveries.Count == 0) return StatusCode(204);
            return Ok(deliveries);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound(e.StackTrace);
        }
    }

    [Authorize]
    [HttpGet("/delivery/all/byDeliveryDate")]
    public async Task<ActionResult> getAllByDeliveryDate([FromQuery] string deliveryDate) {
        try {
            var deliveries = await deliveryRepository.getAllByDeliveryDate(Convert.ToDateTime(deliveryDate));

            if (deliveries.Count == 0) return StatusCode(204);
            return Ok(deliveries);
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
    [HttpGet("/delivery/")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var delivery = await deliveryRepository.getById(id);

            if (delivery == null) return NotFound();
            return Ok(delivery);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/deliveries/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            // var res = await deliveryRepository.deleteById(id);
            var res = await deliveryRepository.getById(id) != null;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e.StackTrace);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/deliveries/delete/all")]
    public async Task<ActionResult> deleteAll() {
        try {
            // var res = await deliveryRepository.deleteAll();
            var res = (await deliveryRepository.getAll()).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/deliveries/delete/byDeliveryDate")]
    public async Task<ActionResult> deleteAllByDeliveryDate([FromQuery] string dateString) {
        try {
            // var res = await deliveryRepository.deleteAllByDeliveryDate(Convert.ToDateTime(dateString));
            var res = (await deliveryRepository.getAllByDeliveryDate(Convert.ToDateTime(dateString))).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (FormatException e) {
            Console.WriteLine(e.StackTrace);
            return BadRequest(e.StackTrace);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/deliveries/delete/byBookId")]
    public async Task<ActionResult> deleteAllByBookId([FromQuery] int bookId) {
        try {
            // var res = await deliveryRepository.deleteAllByBookId(bookId);
            var res = (await deliveryRepository.getAllByBookId(bookId)).Count != 0;

            return res ? Ok() : StatusCode(500);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPost("/deliveries/create")]
    public async Task<ActionResult> createDelivery([FromBody] Delivery delivery) {
        try {
            // var book = await bookRepository.getById(delivery.bookId);
            //
            // if (book == null) {
            //     var catRes = await categoryRepository.getById(delivery.book.categoryId) ??
            //                  await categoryRepository.create(delivery.book.category);
            //
            //     var pubRes = await publisherRepository.getById(delivery.book.publisherId) ??
            //                  await publisherRepository.createPublisher(delivery.book.publisher);
            //
            //     if (pubRes != null) {
            //         delivery.book.publisher = pubRes;
            //         delivery.book.publisherId = pubRes.id;
            //     }
            //
            //     if (catRes != null) {
            //         delivery.book.category = catRes;
            //         delivery.book.categoryId = catRes.id;
            //     }
            //
            //     book = await bookRepository.createBook(delivery.book) ??
            //            throw new ArgumentException("Impossible to insert new book");
            // }
            //
            // delivery.book = book;
            // delivery.bookId = book.id;
            var res = await deliveryRepository.createDelivery(delivery);
            return res != null ? Ok(res) : StatusCode(500);
        }
        catch (ArgumentException e) {
            Console.WriteLine(e.StackTrace);
            return BadRequest(e.Message);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpPut("/deliveries/update")]
    public async Task<ActionResult> update([FromBody] Delivery delivery) {
        try {
            // var book = await bookRepository.getById(delivery.bookId);
            //
            // if (book == null) {
            //     var catRes = await categoryRepository.getById(delivery.book.categoryId) ??
            //                  await categoryRepository.create(delivery.book.category);
            //
            //     var pubRes = await publisherRepository.getById(delivery.book.publisherId) ??
            //                  await publisherRepository.createPublisher(delivery.book.publisher);
            //
            //     if (pubRes != null) {
            //         delivery.book.publisher = pubRes;
            //         delivery.book.publisherId = pubRes.id;
            //     }
            //
            //     if (catRes != null) {
            //         delivery.book.category = catRes;
            //         delivery.book.categoryId = catRes.id;
            //     }
            //
            //     Console.WriteLine(delivery.book);
            //     delivery.book = await bookRepository.createBook(delivery.book) ??
            //                     throw new ArgumentException("Impossible to insert new book");
            //     delivery.bookId = delivery.book.id;
            // }

            var res = await deliveryRepository.updateDelivery(delivery);
            return res ? Ok() : StatusCode(500);
        }
        catch (ArgumentException e) {
            Console.WriteLine(e.StackTrace);
            return BadRequest(e.Message);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }
}