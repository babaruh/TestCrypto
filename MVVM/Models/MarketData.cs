using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestCrypto.MVVM.Models;

public class MarketData
{
    [JsonProperty("current_price")]
    public Dictionary<string, decimal> CurrentPrice { get; set; }
    
    [JsonProperty("market_cap")]
    public Dictionary<string, decimal> MarketCap { get; set; }
    
    [JsonProperty("ath")]
    public Dictionary<string, decimal> Ath { get; set; }
    
    [JsonProperty("fully_diluted_valuation")]
    public Dictionary<string, decimal> FullyDilutedValuation { get; set; }
    
    [JsonProperty("total_volume")]
    public Dictionary<string, decimal> TotalVolume { get; set; }
    
    [JsonProperty("price_change_percentage_24h")]
    public decimal PriceChangePercentage24H { get; set; }
    
    [JsonProperty("price_change_percentage_7d")]
    public decimal PriceChangePercentage7D { get; set; }
    
    [JsonProperty("price_change_percentage_30d")]
    public decimal PriceChangePercentage30D { get; set; }
    
    [JsonProperty("circulating_supply")]
    public decimal CirculatingSupply { get; set; }
}