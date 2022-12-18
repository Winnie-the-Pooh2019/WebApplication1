using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Config;
using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : ControllerBase {

    private readonly IUsersRepository usersRepository;
    private readonly IConfiguration configuration;
    
    public MainController(IUsersRepository usersRepository, IConfiguration configuration) {
        this.usersRepository = usersRepository;
        this.configuration = configuration;
    }

    [HttpPost("/login")]
    public ActionResult login(UserDto user) {
        var actualUser = usersRepository.getByUsername(user.name);

        var claims = new List<Claim>() {
            // new (ClaimsIdentity.DefaultNameClaimType, actualUser.name),
            // new(ClaimsIdentity.DefaultRoleClaimType, actualUser.role),
            new(ClaimTypes.Name, actualUser.name),
            new(ClaimTypes.Role, actualUser.role)
        };

        var identity = new ClaimsIdentity(
            claims, "Token",
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        var jwt = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            // notBefore: DateTime.Now,
            claims: identity.Claims,
            expires: DateTime.Now.Add(TimeSpan.FromHours(2)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                configuration["Jwt:Key"] ?? throw new InvalidOperationException())), SecurityAlgorithms.HmacSha256)
        );

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return Ok(encodedJwt);
    }

    [Authorize(Roles = "admin")]
    [HttpGet]
    public ActionResult get() {
        // var users = from u in context.users
        //     join ru in context.roleUsers
        //         on u.id equals ru.usersid
        //     join r in context.roles
        //         on ru.usersid equals r.id
        //     select new {
        //         userId = u.id,
        //         name = u.name,
        //         surname = u.surname,
        //         role = r.name
        //     };

        return Ok(
        new {
            answer = "hello"
        });
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