using Newtonsoft.Json;

namespace CoinGecko.Models;

// Community data
public class CoinGeckoCommunityData
{
    // Facebook likes
    [JsonProperty("facebook_likes")]
    public int? FacebookLikes { get; set; }
    
    // Twitter followers
    [JsonProperty("twitter_followers")]
    public int? TwitterFollowers { get; set; }
    
    // Average amount of reddit posts per 48 hours
    [JsonProperty("reddit_average_posts_48h")]
    public decimal? RedditAveragePostsPer48h { get; set; }
    
    // Average amount of reddit comments per 48 hours
    [JsonProperty("reddit_average_comments_48h")]
    public decimal? RedditAverageCommentsPer48h { get; set; }
    
    // Reddit subscribers
    [JsonProperty("reddit_subscribers")]
    public int? RedditSubscribers { get; set; }
    
    // Active reddit subscribers last 48 hours
    [JsonProperty("reddit_accounts_active_48h")]
    public decimal? RedditActiveAccounts48h { get; set; }
    
    // Telegram channel user count
    [JsonProperty("telegram_channel_user_count")]
    public int? TelegramChannelUserCount { get; set; }
}