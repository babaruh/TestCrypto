using Newtonsoft.Json;

namespace CoinGecko.Models;

// Public interest statistics
public class CoinGeckoPublicInterestStats
{
    // Alexa rank
    [JsonProperty("alexa_rank")]
    public int? AlexaRank { get; set; }
    
    // Bing matches
    [JsonProperty("bing_matches")]
    public int? BingMatches { get; set; }
}