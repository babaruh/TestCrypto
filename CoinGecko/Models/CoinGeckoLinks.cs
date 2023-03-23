using Newtonsoft.Json;

namespace CoinGecko.Models;

// Links
public class CoinGeckoLinks
{
    // Homepage
    public IEnumerable<string> Homepage { get; set; } = Array.Empty<string>();

    // Blockchain explorer links
    [JsonProperty("blockchain_site")]
    public IEnumerable<string> BlockchainSites { get; set; } = Array.Empty<string>();

    // Official forum urls
    [JsonProperty("official_forum_url")]
    public IEnumerable<string> OfficialForumUrls { get; set; } = Array.Empty<string>();

    // Chat urls
    [JsonProperty("chat_url")]
    public IEnumerable<string> ChatUrls { get; set; } = Array.Empty<string>();

    // Announcement urls
    [JsonProperty("announcement_url")]
    public IEnumerable<string> AnnouncementUrls { get; set; } = Array.Empty<string>();
    
    // Twitter name
    [JsonProperty("twitter_screen_name")]
    public string TwitterScreenName { get; set; } = string.Empty;

    // Facebook name
    [JsonProperty("facebook_username")]
    public string FacebookName { get; set; } = string.Empty;

    // BitcoinTalk thread identifier
    [JsonProperty("bitcointalk_thread_identifier")]
    public string? BitcoinTalkThreadIdentifier { get; set; } = string.Empty;

    // Telegram channel identifier
    [JsonProperty("telegram_channel_identifier")]
    public string? TelegramChannelIdentifier { get; set; } = string.Empty;

    // Subreddit url
    [JsonProperty("subreddit_url")]
    public string? SubredditUrl { get; set; } = string.Empty;

    // Git repository urls
    [JsonProperty("repos_url")]
    public Dictionary<string, IEnumerable<string>> RepoUrls { get; set; } = new();
}