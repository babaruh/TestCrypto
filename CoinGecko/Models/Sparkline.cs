using Newtonsoft.Json;

namespace CoinGecko.Models;

public class Sparkline
{
    [JsonProperty("price")]
    public double[] Price { get; set; }
}