using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public class SubscriptionStore
{
    private readonly List<Subscription> _subscriptions = new();

    public bool AddSubscription(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }

        var normalizedUrl = url.Trim();

        if (_subscriptions.Any(item => string.Equals(item.Url, normalizedUrl, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        _subscriptions.Add(new Subscription(normalizedUrl));
        return true;
    }

    public List<Subscription> GetSubscriptions()
    {
        return _subscriptions.ToList();
    }
}
