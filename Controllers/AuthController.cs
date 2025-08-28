using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class authController : ControllerBase
{
    private readonly IConfiguration _config;

    private readonly MongoDbService _mongoService;

    public authController(MongoDbService mongoService, IConfiguration configuration)
    {
        _mongoService = mongoService;
        _config = configuration;

        Console.WriteLine("AuthController initialized with token: " + _config["Jwt:Secret"]);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var user = await _mongoService.GetCollection<User>("Users")
            .Find(u => u.Username == loginRequest.Username && u.Email == loginRequest.Email)
            .FirstOrDefaultAsync();

        // On success, generate JWT
        var token = JwtHelper.GenerateToken(loginRequest.Username, _config);
        return Ok(new { token });
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(RegisterDto register)
    {
        // TODO: Save new user to MongoDB
        return Ok(new { message = "User registered successfully" });
    }


}