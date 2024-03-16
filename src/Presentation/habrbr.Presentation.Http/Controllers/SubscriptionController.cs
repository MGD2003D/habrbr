#pragma warning disable IDE0037
#pragma warning disable ASP0023

using Microsoft.AspNetCore.Mvc;
using habrbr.Application.Contracts;
using Models;

namespace Habrbr.Presentation.Http.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }
    
    [HttpPost]
    public ActionResult AddSubscription([FromBody] Subscription subscription)
    {
        _subscriptionService.AddSubscription(subscription);
        return Ok(new { message = "Вы подписаны!", subscriptionId = subscription.ID });
    }
    
    [HttpGet("user/{userId}")]
    public ActionResult<IEnumerable<Subscription>> GetSubscriptionsByUserId(int userId)
    {
        IEnumerable<Subscription> subscriptions = _subscriptionService.GetSubscriptionsByUserId(userId);
        if (!subscriptions.Any())
        {
            return NotFound();
        }
        return Ok(subscriptions);
    }

    
    [HttpDelete("{subscriptionId}")]
    public IActionResult DeleteSubscription(int subscriptionId)
    {
        _subscriptionService.DeleteSubscription(subscriptionId);
        return Ok(new { message = "Вы отписаны!", subscriptionId = subscriptionId });
    }
}