namespace Contracts;

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
        return _subscriptionRepository.GetByUserId(userId);
    }

    public void DeleteSubscription(int subscriptionId)
    {
        _subscriptionRepository.Delete(subscriptionId);
    }
}
