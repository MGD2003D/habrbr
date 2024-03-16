using Microsoft.EntityFrameworkCore;
using Models;
using habrbr.Infrastructure.Persistence.Contexts;

namespace habrbr.Infrastructure.Persistence.Repositories;


public interface IArticleRepository
{
    void Add(Article article);
    Article? GetById(int id);
    void Update(Article article);
    void Delete(int id);
}

public class ArticleRepository : IArticleRepository
{
    private readonly ApplicationDbContext _context;

    public ArticleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Article article)
    {
        _context.Articles.Add(article);
        _context.SaveChanges();
    }

    public Article? GetById(int id)
    {
        return _context.Articles
            .Include(a => a.Author)
            .Include(a => a.Comments)
            .FirstOrDefault(a => a.ID == id);
    }

    public void Update(Article article)
    {
        _context.Articles.Update(article);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Article? article = _context.Articles.Find(id);
        if (article != null)
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }
    }
}
