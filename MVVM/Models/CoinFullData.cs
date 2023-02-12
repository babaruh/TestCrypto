using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestCrypto.MVVM.Models;

public class CoinFullData
{
    [JsonProperty("name")] 
    public string Name { get; set; }
    
    [JsonProperty("symbol")] 
    public string Symbol { get; set; }
    
    [JsonProperty("market_cap_rank")]
    public decimal MarketCapRank { get; set; }
    
    [JsonProperty("links")]
    public Links Links { get; set; }
    
    [JsonProperty("market_data", NullValueHandling = NullValueHandling.Ignore)]
    public MarketData MarketData { get; set; }
    
    [JsonProperty("tickers")]
    public Ticker[] Tickers { get; set; }
}