using Newtonsoft.Json;

namespace CoinGecko.Models;

/// Asset market info
public class CoinGeckoAssetMarket
{
    /// Name
    public string Name { get; set; } = string.Empty;
    
    /// Identifier
    public string Identifier { get; set; } = string.Empty;
    
    /// Has trading incentive
    [JsonProperty("has_trading_incentive")]
    public bool HasTradingIncentive { get; set; }
}