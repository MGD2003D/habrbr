#pragma warning disable IDE0008

using Microsoft.AspNetCore.Mvc;
using habrbr.Application.Contracts;
using Models;

namespace Habrbr.Presentation.Http.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRightsInBlogController : ControllerBase
{
    private readonly IUserRightsInBlogService _userRightsInBlogService;

    public UserRightsInBlogController(IUserRightsInBlogService userRightsInBlogService)
    {
        _userRightsInBlogService = userRightsInBlogService;
    }

    [HttpPost]
    public ActionResult AssignRights([FromBody] UserRightsInBlog userRightsInBlog)
    {
        _userRightsInBlogService.AssignRights(userRightsInBlog);
        return CreatedAtAction(nameof(GetRightsById), new { id = userRightsInBlog.ID }, userRightsInBlog);
    }

    [HttpGet("{id}")]
    public ActionResult<UserRightsInBlog> GetRightsById(int id)
    {
        var userRightsInBlog = _userRightsInBlogService.GetRightsById(id);
        if (userRightsInBlog == null)
        {
            return NotFound();
        }
        return Ok(userRightsInBlog);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRights(int id, [FromBody] UserRightsInBlog userRightsInBlog)
    {
        if (id != userRightsInBlog.ID)
        {
            return BadRequest("User Rights In Blog ID mismatch");
        }

        var existingRights = _userRightsInBlogService.GetRightsById(id);
        if (existingRights == null)
        {
            return NotFound($"User Rights In Blog with ID {id} not found.");
        }

        _userRightsInBlogService.UpdateRights(userRightsInBlog);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RevokeRights(int id)
	{
    	UserRightsInBlog? existingRights = _userRightsInBlogService.GetRightsById(id);
    	if (existingRights == null)
    	{
        	return NotFound($"User Rights In Blog with ID {id} not found.");
    	}

    	_userRightsInBlogService.RevokeRights(id);
    	return NoContent();
	}
}
