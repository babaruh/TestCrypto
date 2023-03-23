using Newtonsoft.Json;

namespace CoinGecko.Models;

// Platform info
public class CoinGeckoPlatform
{
    // Decimal places
    [JsonProperty("decimail_places")]
    public int DecimalPlaces { get; set; }

    // Address
    [JsonProperty("contract_address")]
    public string ContractAddress { get; set; } = string.Empty;
}