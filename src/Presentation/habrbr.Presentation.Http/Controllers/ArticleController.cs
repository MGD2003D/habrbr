#pragma warning disable IDE0008

using Microsoft.AspNetCore.Mvc;
using habrbr.Application.Contracts;
using Models;

namespace Habrbr.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet("{id}")]
    public ActionResult<Article> Get(int id)
    {
        var article = _articleService.GetArticleById(id);
        if (article == null)
        {
            return NotFound();
        }
        return Ok(article);
    }

    [HttpPost]
    public ActionResult<Article> Post(Article article)
    {
        _articleService.AddArticle(article);
        return CreatedAtAction(nameof(Get), new { id = article.ID }, article);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Article article)
    {
        if (id != article.ID)
        {
            return BadRequest();
        }
        
        _articleService.UpdateArticle(article);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _articleService.DeleteArticle(id);
        return NoContent();
    }
}