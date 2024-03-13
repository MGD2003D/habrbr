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
    public void Add(Subscription subscription)
    {
        // Пустышка
    }

    public IEnumerable<Subscription> GetSubscriptionsByUserId(int userId)
    {
        // Пустышка
        return new List<Subscription> { new Subscription() };
    }


    public void Delete(int id)
    {
        // Пустышка
    }
}