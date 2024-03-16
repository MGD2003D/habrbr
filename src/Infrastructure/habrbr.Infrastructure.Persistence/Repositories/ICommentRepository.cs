using Microsoft.EntityFrameworkCore;
using Models;
using habrbr.Infrastructure.Persistence.Contexts;

namespace habrbr.Infrastructure.Persistence.Repositories;

using Models;

public interface ICommentRepository
{
    void Add(Comment comment);
    Comment? GetById(int id);
    void Update(Comment comment);
    void Delete(int id);
}

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

    public Comment? GetById(int id)
    {
        return _context.Comments
            .Include(c => c.Author)
            .Include(c => c.ParentArticle)
            .FirstOrDefault(c => c.ID == id);
    }

    public void Update(Comment comment)
    {
        _context.Comments.Update(comment);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Comment? comment = _context.Comments.Find(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}