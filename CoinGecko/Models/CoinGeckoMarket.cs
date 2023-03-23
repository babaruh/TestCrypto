using Newtonsoft.Json;

namespace CoinGecko.Models;

public class CoinGeckoMarket
{
    // Market id
    public string Id { get; set; } = string.Empty;

    // Market symbol
    public string Symbol { get; set; } = string.Empty;

    // Name
    public string Name { get; set; } = string.Empty;
        
    // Image
    public string Image { get; set; } = string.Empty;
    
    // Current price
    [JsonProperty("current_price")]
    public decimal CurrentPrice { get; set; }

    // Market cap
    [JsonProperty("market_cap")]
    public decimal MarketCap { get; set; }
        
    // Market cap rank
    [JsonProperty("market_cap_rank")]
    public decimal MarketCapRank { get; set; }

    // Fully diluted valuation
    [JsonProperty("fully_diluted_valuation")]
    public decimal? FullyDilutedValuation { get; set; }

    // Total trade volume
    [JsonProperty("total_volume")]
    public decimal TotalVolume { get; set; }

    // 24 hour high price
    [JsonProperty("high_24h")]
    public decimal High24h { get; set; }

    // 24 hour low price
    [JsonProperty("low_24h")]
    public decimal Low24h { get; set; }

    // 24 hour price change
    [JsonProperty("price_change_24h")]
    public decimal PriceChange24h { get; set; }

    // 1 hour price change percentage in currency
    [JsonProperty("price_change_percentage_1h_in_currency")]
    public decimal PriceChangePercentage1hInCurrency { get; set; }
    
    // 1 hour price change percentage in currency
    [JsonProperty("price_change_percentage_24h_in_currency")]
    public decimal PriceChangePercentage24hInCurrency { get; set; }
    
    // 1 hour price change percentage in currency
    [JsonProperty("price_change_percentage_7d_in_currency")]
    public decimal PriceChangePercentage7dInCurrency { get; set; }

    // 24 hour market cap change
    [JsonProperty("market_cap_change_24h")]
    public decimal MarketCapChange24h { get; set; }
       
    // 24 hour market cap change percentage
    [JsonProperty("market_cap_change_percentage_24h")]
    public decimal MarketCapChangePercentage24h { get; set; }

    // Circulating supply
    [JsonProperty("circulating_supply")]
    public decimal CirculatingSupply { get; set; }

    // Total supply
    [JsonProperty("total_supply")]
    public decimal? TotalSupply { get; set; }

    // Max supply
    [JsonProperty("max_supply")]
    public decimal? MaxSupply { get; set; }
    
    // Sparkline in 7 days
    [JsonProperty("sparkline_in_7d")]
    public Sparkline SparklineIn7d { get; set; }

    // All time high price
    [JsonProperty("ath")]
    public decimal AllTimeHigh { get; set; }

    // All time high change percentage
    [JsonProperty("ath_change_percentage")]
    public decimal AllTimeHighChangePercentage { get; set; }
        
    // All time high time
    [JsonProperty("ath_date")]
    public DateTime AllTimeHighTimestamp { get; set; }

    // All time low price
    [JsonProperty("atl")]
    public decimal AllTimeLow { get; set; }

    // All time low change percentage
    [JsonProperty("atl_change_percentage")]
    public decimal AllTimeLowChangePercentage { get; set; }

    // All time low time
    [JsonProperty("atl_date")]
    public DateTime AllTimeLowTimestamp { get; set; }

    // Return on investment
    public CoinGeckoMarketRoi? Roi { get; set; }
      
    // Last updated timestamp
    [JsonProperty("last_updated")]
    public DateTime LastUpdated { get; set; }
}