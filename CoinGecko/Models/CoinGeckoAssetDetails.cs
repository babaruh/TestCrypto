using Newtonsoft.Json;

namespace CoinGecko.Models;

public class CoinGeckoAssetDetails
{
    // Id of the asset
    public string Id { get; set; } = string.Empty;
    
    // Symbol of the asset
    public string Symbol { get; set; } = string.Empty;
     
    // Name of the asset
    public string Name { get; set; } = string.Empty;
     
    // Main platform
    [JsonProperty("asset_platform_id")]
    public string AssetPlatformId { get; set; } = string.Empty;
    
    // Smart contract addresses on different platforms
    public Dictionary<string, string> Platforms { get; set; } = new();
    
    // Platform details
    [JsonProperty("detail_platforms")]
    public Dictionary<string, CoinGeckoPlatform> PlatformDetails { get; set; } = new();
    
    // Block generation time
    [JsonProperty("block_time_in_minutes")]
    public int BlockTimeInMinutes { get; set; }
    
    // Hashing algorithm
    [JsonProperty("hashing_algorithm")]
    public string HashingAlgorithm { get; set; } = string.Empty;
    
    // Categories
    public IEnumerable<string> Categories { get; set; } = Array.Empty<string>();
    
    // Public notice
    [JsonProperty("public_notice")]
    public string PublicNotice { get; set; } = string.Empty;
    
    // Additional notices
    [JsonProperty("additional_notices")]
    public IEnumerable<string> AdditionalNotice { get; set; } = Array.Empty<string>();
    
    // Name in different languages
    public Dictionary<string, string> Localization { get; set; } = new();
     
    // Description in different languages
    public Dictionary<string, string> Description { get; set; } = new();
    
    // Links
    public CoinGeckoLinks Links { get; set; } = null!;
    
    // Images
    public CoinGeckoImages Image { get; set; } = null!;
    
    // Country of origin
    [JsonProperty("country_origin")]
    public string CountryOrigin { get; set; } = string.Empty;
    
    // Genesis block date
    [JsonProperty("genesis_date")]
    public DateTime? GenesisDate { get; set; }
    
    // Contract address
    [JsonProperty("contract_address")] 
    public string? ContractAddress { get; set; } = string.Empty;
    
    // Sentiment up votes percentage
    [JsonProperty("sentiment_votes_up_percentage")]
    public decimal? SentimentVotesUpPercentage { get; set; }
    
    // Sentiment down votes percentage
    [JsonProperty("sentiment_votes_down_percentage")]
    public decimal? SentimentVotesDownPercentage { get; set; }
    
    // Ico data
    [JsonProperty("ico_data")]
    public CoinGeckoIcoData? IcoData { get; set; }
    
    // Market cap rank
    [JsonProperty("market_cap_rank")]
    public int? MarketCapRank { get; set; }
    
    // Coin gecko rank
    [JsonProperty("coingecko_rank")]
    public int CoinGeckoRank { get; set; }
    
    // Coin gecko score
    [JsonProperty("coingecko_score")]
    public decimal CoinGeckoScore { get; set; }
    
    // Developer score
    [JsonProperty("developer_score")]
    public decimal DeveloperScore { get; set; }
    
    // Community score
    [JsonProperty("community_score")]
    public decimal CommunityScore { get; set; }
    
    // Liquidity score
    [JsonProperty("liquidity_score")]
    public decimal LiquidityScore { get; set; }
    
    // Public interest score
    [JsonProperty("public_interest_score")]
    public decimal PublicInterestScore { get; set; }
    
    // Market data
    [JsonProperty("market_data")]
    public CoinGeckoMarketData? MarketData { get; set; }
    
    // Public interest statistics
    [JsonProperty("public_interest_stats")]
    public CoinGeckoPublicInterestStats? PublicInterestStats { get; set; }
    
    // Status updates
    [JsonProperty("status_updates")]
    public IEnumerable<CoinGeckoStatusUpdate> StatusUpdates { get; set; } = Array.Empty<CoinGeckoStatusUpdate>();
     
    // Community data
    [JsonProperty("community_data")]
    public CoinGeckoCommunityData? CommunityData { get; set; }
    
    // Developer data
    [JsonProperty("developer_data")]
    public CoinGeckoDeveloperData? DeveloperData { get; set; }
    
    // Last updated
    [JsonProperty("last_updated")]
    public DateTime? LastUpdated { get; set; }
    
    // Tickers
    public IEnumerable<CoinGeckoTicker> Tickers { get; set; } = Array.Empty<CoinGeckoTicker>();
}