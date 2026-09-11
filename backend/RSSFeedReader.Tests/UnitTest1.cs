using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Tests;

public class SubscriptionStoreTests
{
    [Fact]
    public void AddSubscription_AddsUrlToList()
    {
        var store = new SubscriptionStore();

        var added = store.AddSubscription("https://example.com/feed.xml");

        Assert.True(added);
        Assert.Contains(new Subscription("https://example.com/feed.xml"), store.GetSubscriptions());
    }

    [Fact]
    public void AddSubscription_IgnoresBlankAndDuplicateUrls()
    {
        var store = new SubscriptionStore();

        Assert.False(store.AddSubscription("   "));
        Assert.True(store.AddSubscription("https://example.com/feed1.xml"));
        Assert.False(store.AddSubscription("https://example.com/feed1.xml"));
        Assert.Equal(1, store.GetSubscriptions().Count);
    }
}
