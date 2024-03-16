#pragma warning disable IDE0008

using Microsoft.AspNetCore.Mvc;
using habrbr.Application.Contracts;
using Models;

namespace Habrbr.Presentation.Http.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpPost]
    public ActionResult<Comment> Post([FromBody] Comment comment)
    {
        _commentService.AddComment(comment);
        return CreatedAtAction(nameof(Get), new { id = comment.ID }, comment);
    }
    
    [HttpGet("{id}")]
    public ActionResult<Comment> Get(int id)
    {
        var comment = _commentService.GetCommentById(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Comment comment)
    {
        if (id != comment.ID)
        {
            return BadRequest("Comment ID mismatch");
        }
        
        var existingComment = _commentService.GetCommentById(id);
        if (existingComment == null)
        {
            return NotFound($"Comment with ID {id} not found.");
        }

        _commentService.UpdateComment(comment);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Comment? existingComment = _commentService.GetCommentById(id);
        if (existingComment == null)
        {
            return NotFound($"Comment with ID {id} not found.");
        }

        _commentService.DeleteComment(id);
        return NoContent();
    }
}