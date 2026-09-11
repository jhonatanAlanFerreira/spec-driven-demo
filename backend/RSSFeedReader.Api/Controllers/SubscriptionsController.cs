using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly SubscriptionStore _store;

    public SubscriptionsController(SubscriptionStore store)
    {
        _store = store;
    }

    [HttpGet]
    public ActionResult<object> Get()
    {
        return Ok(new { subscriptions = _store.GetSubscriptions().Select(item => item.Url).ToList() });
    }

    [HttpPost]
    public ActionResult<object> Post([FromBody] AddSubscriptionRequest? request)
    {
        if (string.IsNullOrWhiteSpace(request?.Url))
        {
            return BadRequest(new { message = "A feed URL is required." });
        }

        var added = _store.AddSubscription(request.Url);
        if (!added)
        {
            return Conflict(new { message = "The feed is already subscribed or the value is invalid." });
        }

        return Ok(new { subscriptions = _store.GetSubscriptions().Select(item => item.Url).ToList() });
    }
}
