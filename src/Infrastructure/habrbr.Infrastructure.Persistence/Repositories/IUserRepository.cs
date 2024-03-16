using Microsoft.EntityFrameworkCore;
using Models;
using habrbr.Infrastructure.Persistence.Contexts;

namespace habrbr.Infrastructure.Persistence.Repositories;

using Models;
public interface IUserRepository
{
    void Add(User user);
    User? GetById(int id);
    void Update(User user);
    void Delete(int id);
}

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? GetById(int id)
    {
        return _context.Users.Include(u => u.Blogs).FirstOrDefault(u => u.ID == id);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        User? user = _context.Users.Find(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
