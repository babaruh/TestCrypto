using Newtonsoft.Json;

namespace CoinGecko.Models;

/// Market data
public class CoinGeckoMarketData
{ 
    // Current price
    [JsonProperty("current_price")]
    public Dictionary<string, decimal> CurrentPrice { get; set; } = new();
        
    // Total value locked
    [JsonProperty("total_value_locked")]
    public decimal? TotalValueLocked { get; set; }
        
    // Market cap to total value locked ratio
    [JsonProperty("mcap_to_tvl_ratio")]
    public decimal? MarketCapToTotalValueLockedRatio { get; set; }
    
    // Fully diluted valuation to total value locked ratio
    [JsonProperty("fdv_to_tvl_ratio")]
    public decimal? FullyDilutedValuationToTotalValueLockedRatio { get; set; }
        
    // Return on investment
    public CoinGeckoMarketRoi? Roi { get; set; }
    
    // All time high prices
    [JsonProperty("ath")]
    public Dictionary<string, decimal> AllTimeHighs { get; set; } = new();
        
    // Current price change vs all time high
    [JsonProperty("ath_change_percentage")]
    public Dictionary<string, decimal> AllTimeHighChangePercentages { get; set; } = new();
    
    // All time high dates
    [JsonProperty("ath_date")]
    public Dictionary<string, DateTime> AllTimeHighDates { get; set; } = new();
        
    // All time low prices
    [JsonProperty("atl")] 
    public Dictionary<string, decimal> AllTimeLows { get; set; } = new();
        
    // Current price change vs all time low
    [JsonProperty("atl_change_percentage")]
    public Dictionary<string, decimal> AllTimeLowChangePercentages { get; set; } = new();
        
    // All time low dates
    [JsonProperty("atl_date")]
    public Dictionary<string, DateTime> AllTimeLowDates { get; set; } = new();
        
    // Market caps
    [JsonProperty("market_cap")]
    public Dictionary<string, decimal> MarketCaps { get; set; } = new();
        
    // Market cap rank
    [JsonProperty("market_cap_rank")]
    public int? MarketCapRank { get; set; }
        
    // Fully diluted valuation
    [JsonProperty("fully_diluted_valuation")]
    public Dictionary<string, decimal> FullyDilutedValuations { get; set; } = new();
        
    // Total volumes
    [JsonProperty("total_volume")]
    public Dictionary<string, decimal> TotalVolumes { get; set; } = new();
        
    // 24h high prices
    [JsonProperty("high_24h")]
    public Dictionary<string, decimal?> High24h { get; set; } = new();
        
    // 24h low prices
    [JsonProperty("low_24h")]
    public Dictionary<string, decimal?> Low24h { get; set; } = new();
        
    // 24h price change
    [JsonProperty("price_change_24h")]
    public decimal? PriceChange24h { get; set; }
        
    // 24h price change percentage
    [JsonProperty("price_change_percentage_24h")]
    public decimal? PriceChangePercentage24h { get; set; }
        
    // 7 day price change percentage
    [JsonProperty("price_change_percentage_7d")]
    public decimal PriceChangePercentage7d { get; set; }
        
    // 14 day price change percentage
    [JsonProperty("price_change_percentage_14d")]
    public decimal PriceChangePercentage14d { get; set; }
        
    // 30 day price change percentage
    [JsonProperty("price_change_percentage_30d")]
    public decimal PriceChangePercentage30d { get; set; }
        
    // 60 day price change percentage
    [JsonProperty("price_change_percentage_60d")]
    public decimal PriceChangePercentage60d { get; set; }
        
    // 200 day price change percentage
    [JsonProperty("price_change_percentage_200d")]
    public decimal PriceChangePercentage200d { get; set; }
        
    // 1 year price change percentage
    [JsonProperty("price_change_percentage_1y")]
    public decimal PriceChangePercentage1y { get; set; }
        
    // 24 hour market cap change
    [JsonProperty("market_cap_change_24h")]
    public decimal? MarketCapChange24h { get; set; }
        
    // 24 hour market cap change
    [JsonProperty("market_cap_change_percentage_24h")]
    public decimal? MarketCapChangePercentage24h { get; set; }
        
    // 24h price changes
    [JsonProperty("price_change_24h_in_currency")]
    public Dictionary<string, decimal?> PriceChanges24h { get; set; } = new();
        
    // 1h price changes percentages
    [JsonProperty("price_change_percentage_1h_in_currency")]
    public Dictionary<string, decimal?> PriceChangePerecentages1h { get; set; } = new();
        
    // 24h price changes percentages
    [JsonProperty("price_change_percentage_24h_in_currency")]
    public Dictionary<string, decimal?> PriceChangePerecentages24h { get; set; } = new();
        
    // 7d price change percentages
    [JsonProperty("price_change_percentage_7d_in_currency")]
    public Dictionary<string, decimal?> PriceChangePerecentages7d { get; set; } = new();
        
    // 14d price change percentages
    [JsonProperty("price_change_percentage_14d_in_currency")]
    public Dictionary<string, decimal?> PriceChangePerecentages14d { get; set; } = new();
        
    // 30d price change percentages
    [JsonProperty("price_change_percentage_30d_in_currency")]
    public Dictionary<string, decimal?> PriceChangePerecentages30d { get; set; } = new();
        
    // 60d price change percentages
    [JsonProperty("price_change_percentage_60d_in_currency")]
    public Dictionary<string, decimal?> PriceChangePerecentages60d { get; set; } = new();
    
    // 200d price change percentages
    [JsonProperty("price_change_percentage_200d_in_currency")]
    public Dictionary<string, decimal?> PriceChangePerecentages200d { get; set; } = new();
        
    // 1y price change percentages
    [JsonProperty("price_change_percentage_1y_in_currency")]
    public Dictionary<string, decimal?> PriceChangePerecentages1y { get; set; } = new();
        
    // 24h market cap changes
    [JsonProperty("market_cap_change_24h_in_currency")]
    public Dictionary<string, decimal?> MarketCapChanges24h { get; set; } = new();
        
    // 24h market cap change percentages
    [JsonProperty("market_cap_change_percentage_24h_in_currency")]
    public Dictionary<string, decimal?> MarketCapChangePercentages24h { get; set; } = new();
        
    // Total supply
    [JsonProperty("total_supply")]
    public decimal? TotalSupply { get; set; }
        
    // Max supply
    [JsonProperty("max_supply")]
    public decimal? MaxSupply { get; set; }
        
    // Circulating supply
    [JsonProperty("circulating_supply")]
    public decimal? CirculatingSupply { get; set; }
        
    // Last updated timestamp
    [JsonProperty("last_updated")]
    public DateTime? LastUpdated { get; set; }
    
    // sparkline in 7 days
    [JsonProperty("sparkline_7d")]
    public Sparkline SparklineIn7d { get; set; }
}