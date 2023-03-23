using Newtonsoft.Json;

namespace CoinGecko.Models;

// Ticker info
public class CoinGeckoTicker
{
    // Base asset
    public string Base { get; set; } = string.Empty; 
    
    // Quote asset
    public string Target { get; set; } = string.Empty;
    
    // Market info
    public CoinGeckoAssetMarket? Market { get; set; }
    
    // Last price
    public decimal? Last { get; set; }
    
    // Trade volume
    public decimal? Volume { get; set; }
    
    // Converted last
    [JsonProperty("converted_last")]
    public Dictionary<string, decimal> ConvertedLast { get; set; } = new();
    
    // Converted volume
    [JsonProperty("converted_volume")]
    public Dictionary<string, decimal> ConvertedVolume { get; set; } = new();
    
    // Trust score
    [JsonProperty("trust_score")]
    public string? TrustScore { get; set; }
    
    // Difference in percentage between best bid and ask
    [JsonProperty("bid_ask_spread_percentage")]
    public decimal? BidAskSpreadPercentage { get; set; }
    
    // Timestamp
    public DateTime? Timestamp { get; set; }
    
    // Last trade timestamp
    [JsonProperty("last_traded_at")]
    public DateTime? LastTradedAt { get; set; }
    
    // Last fetch timestamp
    [JsonProperty("last_fetch_at")]
    public DateTime? LastFetchAt { get; set; }
    
    // Is anomaly
    [JsonProperty("is_anomaly")]
    public bool IsAnomaly { get; set; }
    
    // Is stale
    [JsonProperty("is_stale")]
    public bool IsStale { get; set; }
    
    // Trade url
    [JsonProperty("trade_url")]
    public string? TradeUrl { get; set; }
    
    // Token info url
    [JsonProperty("token_info_url")]
    public string? TokenInfoUrl { get; set; }
    
    // Coin id
    [JsonProperty("coin_id")]
    public string? CoinId { get; set; }

    // Target coin id
    [JsonProperty("target_coin_id")]
    public string? TargetCoinId { get; set; }
}