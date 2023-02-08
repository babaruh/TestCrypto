using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace TestCrypto.Models;

public class CoinMarket
{
    [JsonProperty("id")] 
    public string Id { get; set; }
    
    [JsonProperty("name")] 
    public string Name { get; set; }
    
    [JsonProperty("symbol")] 
    public string Symbol { get; set; }
    
    [JsonProperty("image")] 
    public string ImageUri { get; set; }

    [JsonProperty("current_price")] 
    public decimal? CurrentPrice { get; set; }
    
    [JsonProperty("market_cap")] 
    public decimal? MarketCap { get; set; }
    
    [JsonProperty("total_volume")] 
    public decimal? TotalVolume { get; set; }
    
    [JsonProperty("total_supply")] 
    public decimal? TotalSupply { get; set; }
    
    [JsonProperty("price_change_percentage_24h")] 
    public double? PriceChangePercentage24H { get; set; }
}