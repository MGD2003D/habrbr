namespace Models;

public class Subscription
{
    public int ID { get; set; }
    public int SubscriberId { get; set; }
    public User Subscriber { get; set; }
    public int? AuthorId { get; set; }
    public User Author { get; set; }
    public int? BlogId { get; set; }
    public Blog Blog { get; set; }
    public DateTime SubscriptionDate { get; set; }
    public bool IsActive { get; set; }
}
