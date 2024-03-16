using Microsoft.EntityFrameworkCore;
using Models;
using habrbr.Infrastructure.Persistence.Contexts;

namespace habrbr.Infrastructure.Persistence.Repositories;

public interface IUserRightsInBlogRepository
{
    void Add(UserRightsInBlog userRightsInBlog);
    UserRightsInBlog? GetById(int id);
    void Update(UserRightsInBlog userRightsInBlog);
    void Delete(int id);
}

public class UserRightsInBlogRepository : IUserRightsInBlogRepository
{
    private readonly ApplicationDbContext _context;

    public UserRightsInBlogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(UserRightsInBlog userRightsInBlog)
    {
        _context.UserRightsInBlogs.Add(userRightsInBlog);
        _context.SaveChanges();
    }

    public UserRightsInBlog? GetById(int id)
    {
        return _context.UserRightsInBlogs
            .Include(ur => ur.User)
            .Include(ur => ur.Blog)
            .FirstOrDefault(ur => ur.ID == id);
    }

    public void Update(UserRightsInBlog userRightsInBlog)
    {
        _context.UserRightsInBlogs.Update(userRightsInBlog);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        UserRightsInBlog? userRightsInBlog = _context.UserRightsInBlogs.Find(id);
        if (userRightsInBlog != null)
        {
            _context.UserRightsInBlogs.Remove(userRightsInBlog);
            _context.SaveChanges();
        }
    }
}