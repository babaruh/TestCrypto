using Newtonsoft.Json;

namespace TestCrypto.MVVM.Models;

public class Market
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("identifier")]
    public string Identifier { get; set; }

    [JsonProperty("has_trading_incentive")]
    public bool HasTradingIncentive { get; set; }
}