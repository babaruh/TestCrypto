using Newtonsoft.Json;

namespace TestCrypto.MVVM.Models;

public class Ticker
{
    [JsonProperty("last")]
    public decimal Last { get; set; }
    
    [JsonProperty("market")]
    public Market Market { get; set; }
    
    [JsonProperty("volume")]
    public decimal Volume { get; set; }
    
    [JsonProperty("trust_score")]
    public string TrustScore { get; set; }
    
    [JsonProperty("trade_url")]
    public string TradeUrl { get; set; }
}