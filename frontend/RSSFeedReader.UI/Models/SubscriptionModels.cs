namespace RSSFeedReader.UI.Models;

public class SubscriptionListResponse
{
    public List<string> Subscriptions { get; set; } = new();
}

public class AddSubscriptionRequest
{
    public string? Url { get; set; }
}
