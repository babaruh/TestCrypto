using Newtonsoft.Json;

namespace TestCrypto.MVVM.Models;

public class Exchange
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("image")]
    public string ImageUrl { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }
    
    [JsonProperty("trust_score")]
    public double? TrustScore { get; set; }

    [JsonProperty("trade_volume_24h_btc")]
    public double? TradeVolume24HBtc { get; set; }
}