using Newtonsoft.Json;

namespace CoinGecko.Models;

public class CoinGeckoMarketRoi
{
    // Times
    public decimal Times { get; set; }
    
    // Investment asset
    [JsonProperty("currency")]
    public string Asset { get; set; } = string.Empty;
    
    // Profit percentage
    public decimal Percentage { get; set; }
}