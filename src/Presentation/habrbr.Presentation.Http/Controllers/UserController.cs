#pragma warning disable IDE0008

using Microsoft.AspNetCore.Mvc;
using habrbr.Application.Contracts;
using Models;

namespace Habrbr.Presentation.Http.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public IActionResult Register([FromBody] User user)
    {
        _userService.RegisterUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.ID }, user);
    }
    
    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        if (id != user.ID)
        {
            return BadRequest("User ID mismatch");
        }

        var existingUser = _userService.GetUserById(id);
        if (existingUser == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        _userService.UpdateUser(user);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        User? user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        _userService.DeleteUser(id);
        return NoContent();
    }
}