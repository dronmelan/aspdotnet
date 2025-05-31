using LibraryReservation.Models;
using LibraryReservation.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IBookingRepository _repository;
    private readonly IConfiguration _config;


    public AuthController(IBookingRepository repository, IConfiguration config)
    {
        _repository = repository;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var user = new User
        {
            Name = dto.Username,
            Email = $"{dto.Username}@test.com",
            PasswordHash = dto.Password,
            Role = "User"
        };

        await _repository.AddAsync<User>(user);
        return Ok(new { message = "Registered successfully" });
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        var user = _repository.Users.FirstOrDefault(u =>
            u.Email == dto.Email && u.PasswordHash == dto.Password);

        if (user == null) return Unauthorized("Invalid credentials");

        var token = GenerateToken(user);
        return Ok(new { token });
    }
    private string GenerateToken(User user)
    {
        var jwtSettings = _config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role ?? "user"),
            new Claim("UserId", user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
