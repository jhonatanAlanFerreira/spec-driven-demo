namespace RSSFeedReader.Api.Models;

public class Subscription
{
    public Subscription(string url)
    {
        Url = url.Trim();
    }

    public string Url { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        return obj is Subscription other && string.Equals(Url, other.Url, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(Url);
    }
}
