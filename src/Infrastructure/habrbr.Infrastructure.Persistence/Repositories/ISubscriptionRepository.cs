using Microsoft.EntityFrameworkCore;
using Models;
using habrbr.Infrastructure.Persistence.Contexts;

namespace habrbr.Infrastructure.Persistence.Repositories;

using Models;

public interface ISubscriptionRepository
{
    void Add(Subscription subscription);
    IEnumerable<Subscription> GetSubscriptionsByUserId(int userId);
    void Delete(int id);
}


public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly ApplicationDbContext _context;

    public SubscriptionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Subscription subscription)
    {
        _context.Subscriptions.Add(subscription);
        _context.SaveChanges();
    }

    public IEnumerable<Subscription> GetSubscriptionsByUserId(int userId)
    {
        return _context.Subscriptions
            .Where(s => (s.Subscriber != null && s.Subscriber.ID == userId) 
                        || (s.Author != null && s.Author.ID == userId))
            .Include(s => s.Subscriber)
            .Include(s => s.Author)
            .Include(s => s.Blog)
            .ToList();
    }



    public void Delete(int id)
    {
        Subscription? subscription = _context.Subscriptions.Find(id);
        if (subscription != null)
        {
            _context.Subscriptions.Remove(subscription);
            _context.SaveChanges();
        }
    }
}