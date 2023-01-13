using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;
using WebApplication1.Data.repo;
using WebApplication1.Utils;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : Controller {
    private readonly IUsersRepository usersRepository;
    private IConfiguration configuration;

    public MainController(IUsersRepository usersRepository, IConfiguration configuration) {
        this.usersRepository = usersRepository;
        this.configuration = configuration;
    }

    [HttpPost("/signin")]
    public async Task<ActionResult> login([FromBody] SignInDto signUp) {
        var person = await usersRepository.getByUsername(signUp.login);
        
        if (person == null || !CryptEncoder.checkPassword(signUp.password, person.password, person.salt))
            return BadRequest(new { errorText = "Invalid username or password." });

        var claims = new List<Claim> {
            new(ClaimsIdentity.DefaultNameClaimType, person.login),
            new(ClaimsIdentity.DefaultRoleClaimType, person.role)
        };
        var claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

        var now = DateTime.UtcNow;
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: claimsIdentity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.getSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new {
            accessToken = encodedJwt,
            username = claimsIdentity.Name,
            role = person.role
        };
        Console.WriteLine(response);

        return Json(response);
    }

    [HttpPost("/signup")]
    public async Task<ActionResult> signUp([FromBody] SignUpDto signUpDto) {
        var userFromDb = await usersRepository.getByUsername(signUpDto.login);
        Console.WriteLine(userFromDb);

        if (userFromDb != null) return BadRequest("This user is already exists");

        if (signUpDto.role == string.Empty) signUpDto.role = "user";
        var user = await usersRepository.createUser(signUpDto);

        return user == null ? StatusCode(500) : Ok();
    }

    [HttpGet("/user/all")]
    public async Task<ActionResult> getAllUsers() {
        try {
            var books = await usersRepository.getAll();

            if (books.Count == 0) return StatusCode(204);
            return Ok(books);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return NotFound("Unable to connect to database");
        }
    }

    [HttpGet("/user/")]
    public async Task<ActionResult> getById([FromQuery] int id) {
        try {
            var category = await usersRepository.getById(id);

            if (category == null) return NotFound();
            return Ok(category);
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, e);
        }
    }

    // [Authorize(Roles = "admin")]
    [HttpPost("/user/create")]
    public async Task<ActionResult> createUser([FromBody] SignUpDto signUpDto) {
        var person = await usersRepository.getByUsername(signUpDto.login);

        if (person != null) return BadRequest("This user is already exists");

        var user = await usersRepository.createUser(signUpDto);

        return user == null ? StatusCode(500) : Ok();
    }

    [Authorize]
    [HttpPut("/user/update")]
    public async Task<ActionResult> updateUser([FromBody] SignUpDto signUpDto) {
        var user = await usersRepository.getByUsername(signUpDto.login);
        
        if (user == null) return BadRequest($"No user found with login {signUpDto.login}");

        var res = await usersRepository.updateUser(signUpDto);

        if (res == false)
            return BadRequest("Cannot update user");

        return Ok();
    }

    [Authorize]
    [HttpPatch("/user/update")]
    public async Task<ActionResult> patchUser([FromBody] SignInDto person) {
        var user = await usersRepository.getByUsername(person.login);
        if (user == null) return BadRequest("No user with such login");

        return await usersRepository.updateUser(user) ? Ok() : StatusCode(500);
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("/user/delete/byId")]
    public async Task<ActionResult> deleteById([FromQuery] int id) {
        try {
            var res = await usersRepository.deleteById(id);
            // var res = await categoryRepository.getById(id) != null;
    
            return res ? Ok() : StatusCode(500, "No user with such id found");
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return StatusCode(500, "Error occured while query executing");
        }
    }

    private async Task<ClaimsIdentity?> getIdentity(string username, string password) {
        User? person = await usersRepository.getByUsername(username);

        if (person == null) return null;

        if (!CryptEncoder.checkPassword(password, person.password, person.salt)) return null;

        var claims = new List<Claim> {
            new(ClaimsIdentity.DefaultNameClaimType, person.login),
            new(ClaimsIdentity.DefaultRoleClaimType, person.role)
        };
        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}