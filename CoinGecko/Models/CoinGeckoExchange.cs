using Newtonsoft.Json;

namespace Console;

/// <summary>
/// Exchange info
/// </summary>
public class CoinGeckoExchange
{
    // Id
    public string Id { get; set; } = string.Empty;
    
    // Name
    public string Name { get; set; } = string.Empty;
    
    // Year established
    [JsonProperty("year_established")]
    public int? YearEstablished { get; set; }
    
    // Country
    public string Country { get; set; } = string.Empty;
    
    // Description
    public string Description { get; set; } = string.Empty;
    
    // Url
    public string Url { get; set; } = string.Empty;
    
    // Image
    public string Image { get; set; } = string.Empty;
    
    // Has a trading incentive
    [JsonProperty("has_trading_incentive")]
    public bool? HasTradingIncentive { get; set; }
    
    // Trust score
    [JsonProperty("trust_score")]
    public string? TrustScore { get; set; }
    
    // Trust score rank
    [JsonProperty("trust_score_rank")]
    public int? TrustScoreRank { get; set; }
    
    // Trading volume in btc last 24h
    [JsonProperty("trade_volume_24h_btc")]
    public decimal? TradeVolume24hBtc { get; set; }
    
    // Normalized trading volume in btc last 24h
    [JsonProperty("trade_volume_24h_btc_normalized")]
    public decimal? TradeVolume24hBtcNormalized { get; set; }
}