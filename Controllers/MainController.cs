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

    [HttpPost("/login")]
    public async Task<ActionResult> login([FromBody] SignInDto signUp) {
        var identity = await getIdentity(signUp.login, signUp.password);

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
            signingCredentials: new SigningCredentials(AuthOptions.getSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new {
            access_token = encodedJwt,
            username = identity.Name
        };

        return Json(response);
    }

    [Authorize(Roles = "admin")]
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
        if (user != null) return BadRequest("This login is already taken");

        var res = await usersRepository.updateUser(signUpDto);

        if (res == false)
            return BadRequest();

        return Ok();
    }

    [Authorize]
    [HttpPatch("/user/update")]
    public async Task<ActionResult> patchUser([FromBody] SignInDto person) {
        var user = await usersRepository.getByUsername(person.login);
        if (user == null) return BadRequest("No user with such login");

        return await usersRepository.updateUser(user) ? Ok() : StatusCode(500);
    }

    private async Task<ClaimsIdentity?> getIdentity(string username, string password) {
        User? person = await usersRepository.getByUsername(username);

        if (person == null) return null;

        if (!CryptEncoder.checkPassword(password, person.password, person.salt)) return null;

        var claims = new List<Claim> {
            new(ClaimsIdentity.DefaultNameClaimType, person.loginName),
            new(ClaimsIdentity.DefaultRoleClaimType, person.role)
        };
        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }
}