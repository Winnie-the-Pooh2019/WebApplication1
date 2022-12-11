using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : ControllerBase {

    private readonly DataContext context;

    public MainController(DataContext context) {
        this.context = context;
    }

    [HttpGet]
    public ActionResult get() {
        var users = from u in context.users
            join ru in context.roleUsers
                on u.id equals ru.usersid
            join r in context.roles
                on ru.usersid equals r.id
            select new {
                userId = u.id,
                name = u.name,
                surname = u.surname,
                role = r.name
            };

        return Ok(users);
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> GetById_ActionResultOfT(int id) {
        var product = new Product(id, "hello");

        return product.id == 3 ? NotFound() : Ok(product);
    }
}

public class Product {
    public int id { get; }

    public Product(int id, string name) {
        this.id = id;
    }
}