using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class authController : ControllerBase
{
    private readonly string _validToken;
    private readonly MongoDbService _mongoService;

    public authController(MongoDbService mongoService, IConfiguration configuration)
    {
        _mongoService = mongoService;
        _validToken = configuration.GetValue<string>("Auth:Token") ?? "default-token";
        Console.WriteLine("AuthController initialized with token: " + _validToken);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var user = await _mongoService.GetCollection<User>("Users")
            .Find(u => u.Username == loginRequest.Username && u.Email == loginRequest.Email)
            .FirstOrDefaultAsync();

        if (user == null) return Unauthorized("Invalid username or password.");
        return Ok(new { token = _validToken });
    }


}