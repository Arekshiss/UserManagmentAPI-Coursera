using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class userController : ControllerBase
{
    private readonly MongoDbService _mongoService;

    public userController(MongoDbService mongoService)
    {
        _mongoService = mongoService;
    }

    // GET: api/user
    [HttpGet("{page?}/{pageSize?}")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers(int page = 1, int pageSize = 10)
    {
        try
        {
            if(page < 1) page = 1;
            var users = await _mongoService.GetCollection<User>("Users")
                .Find(_ => true)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return Ok(users);
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Error retrieving users from the database.");
        }
    }


    // GET: api/user/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        try
        {
            if (id <= 0) return BadRequest("Invalid user ID.");

            var user = await _mongoService.GetCollection<User>("Users")
            .Find(u => u._id == id)
            .FirstOrDefaultAsync();

            if (user == null) return NotFound("User not found.");
            return Ok(user);
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Error retrieving user from the database.");
        }
    }

    // POST: api/user
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User newUser)
    {
        try
        {
            var users = await _mongoService.GetCollection<User>("Users").AsQueryable().ToListAsync();
            newUser._id = users.Count + 1;
            _mongoService.GetCollection<User>("Users").InsertOne(newUser);

            return CreatedAtAction(nameof(GetUserById), new { id = newUser._id }, newUser);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, "Error creating user: " + ex.Message);
        }
    }

    // PUT: api/user/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User updatedUser)
    {
        try
        {
            if (id <= 0) return BadRequest("Invalid user ID");

            var user = await _mongoService.GetCollection<User>("Users")
               .Find(u => u._id == id)
               .FirstOrDefaultAsync();

            if (user == null) return NotFound("User not found");

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            _mongoService.GetCollection<User>("Users").ReplaceOne(u => u._id == id, user);

            return Ok("User updated successfully");
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Error updating user in the database.");
       }
    }

    // DELETE: api/user/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            if (id <= 0) return BadRequest("Invalid user ID");
            var user = await _mongoService.GetCollection<User>("Users")
            .Find(u => u._id == id)
            .FirstOrDefaultAsync();

            if (user == null) return NotFound("User not found");

            _mongoService.GetCollection<User>("Users").DeleteOne(u => u._id == id);

            return Ok("User deleted successfully");
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Error deleting user from the database.");
        }
    }
}