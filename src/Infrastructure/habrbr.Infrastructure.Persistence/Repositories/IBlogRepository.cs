using Microsoft.EntityFrameworkCore;
using Models;
using habrbr.Infrastructure.Persistence.Contexts;

namespace habrbr.Infrastructure.Persistence.Repositories;

using Models;
public interface IBlogRepository
{
    void Add(Blog blog);
    Blog? GetById(int id);
    void Update(Blog blog);
    void Delete(int id);
}

public class BlogRepository : IBlogRepository
{
    private readonly ApplicationDbContext _context;

    public BlogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Blog blog)
    {
        _context.Blogs.Add(blog);
        _context.SaveChanges();
    }

    public Blog? GetById(int id)
    {
        return _context.Blogs
            .Include(b => b.Creator)
            .Include(b => b.Articles)
            .FirstOrDefault(b => b.ID == id);
    }

    public void Update(Blog blog)
    {
        _context.Blogs.Update(blog);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Blog? blog = _context.Blogs.Find(id);
        if (blog != null)
        {
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }
    }
}
