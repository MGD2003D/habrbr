#pragma warning disable IDE0008

using Microsoft.AspNetCore.Mvc;
using habrbr.Application.Contracts;
using Models;

namespace Habrbr.Presentation.Http.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    [HttpPost]
    public ActionResult<Blog> Create([FromBody] Blog blog)
    {
        _blogService.CreateBlog(blog);
        return CreatedAtAction(nameof(GetById), new { id = blog.ID }, blog);
    }
    
    [HttpGet("{id}")]
    public ActionResult<Blog> GetById(int id)
    {
        var blog = _blogService.GetBlogById(id);
        if (blog == null)
        {
            return NotFound($"Blog with ID {id} not found.");
        }
        return Ok(blog);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Blog blog)
    {
        if (id != blog.ID)
        {
            return BadRequest("Blog ID mismatch");
        }

        Blog? existingBlog = _blogService.GetBlogById(id);
        if (existingBlog == null)
        {
            return NotFound($"Blog with ID {id} not found.");
        }

        _blogService.UpdateBlog(blog);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Blog? existingBlog = _blogService.GetBlogById(id);
        if (existingBlog == null)
        {
            return NotFound($"Blog with ID {id} not found.");
        }

        _blogService.DeleteBlog(id);
        return NoContent();
    }
}