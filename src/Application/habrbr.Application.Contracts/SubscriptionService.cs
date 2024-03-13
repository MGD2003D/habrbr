using Models;
using habrbr.Infrastructure.Persistence.Repositories;

namespace habrbr.Application.Contracts;

public interface ISubscriptionService
{
    void AddSubscription(Subscription subscription);
    IEnumerable<Subscription> GetSubscriptionsByUserId(int userId);
    void DeleteSubscription(int subscriptionId);
}

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public void AddSubscription(Subscription subscription)
    {
        _subscriptionRepository.Add(subscription);
    }

    public IEnumerable<Subscription> GetSubscriptionsByUserId(int userId)
    {
        return _subscriptionRepository.GetSubscriptionsByUserId(userId);
    }

    public void DeleteSubscription(int subscriptionId)
    {
        _subscriptionRepository.Delete(subscriptionId);
    }
}
