using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data.Dto;
using WebApplication1.Data.repo;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : Controller {
    
    private readonly IUsersRepository usersRepository;
    private readonly IConfiguration configuration;
    
    public MainController(IUsersRepository usersRepository, IConfiguration configuration) {
        this.usersRepository = usersRepository;
        this.configuration = configuration;
    }

    [HttpPost("/login")]
    public async Task<ActionResult> login(UserDto user) {
        var identity = await getIdentity(user.login);
        
        if (identity == null)
            return BadRequest(new { errorText = "Invalid username or password." });

        var now = DateTime.UtcNow;
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.getSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
 
        var response = new
        {
            access_token = encodedJwt,
            username = identity.Name
        };
 
        return Json(response);
    }

    [Authorize(Roles = "admin")]
    [HttpPost("/user/create")]
    public async Task<ActionResult> createUser(UserDto userDto) {
        var user = await usersRepository.createUser(userDto);

        if (user == null)
            return BadRequest();

        return Ok();
    }

    [Authorize]
    [HttpPost("/user/update")]
    public async Task<ActionResult> updateUser(UserDto userDto) {
        var res = await usersRepository.updateUser(userDto);

        if (res == false)
            return BadRequest();

        return Ok();
    }

    [Authorize]
    [HttpGet]
    public ActionResult get() {
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
    
    private async Task<ClaimsIdentity?> getIdentity(string username) {
        UserDto? person = await usersRepository.getByUsername(username);

        if (person == null) return null;
        
        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, person.login),
            new(ClaimsIdentity.DefaultRoleClaimType, person.role)
        };
        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}

public class Product {
    public int id { get; }

    public Product(int id, string name) {
        this.id = id;
    }
}