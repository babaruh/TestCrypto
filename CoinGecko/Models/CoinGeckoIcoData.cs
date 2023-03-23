using Newtonsoft.Json;

namespace CoinGecko.Models;

/// Ico information
public class CoinGeckoIcoData
{ 
    [JsonProperty("ico_start_date")]
    public DateTime? IcoStartDate { get; set; }
    
    // Ico end date
    [JsonProperty("ico_end_date")]
    public DateTime? IcoEndDate { get; set; }
    
    // Short description
    [JsonProperty("short_desc")]
    public string ShortDescription { get; set; } = string.Empty;
    
    // Description
    public string? Description { get; set; }
    
    // Soft cap currency
    [JsonProperty("softcap_currency")]
    public string? SoftcapCurrency { get; set; }
    
    // Hard cap currency
    [JsonProperty("hardcap_currency")]
    public string? HardcapCurrency { get; set; }
    
    // Total raised currency
    [JsonProperty("total_raised_currency")]
    public string? TotalRaisedCurrency { get; set; }
    
    // Softcap
    [JsonProperty("softcap_amount")]
    public decimal? SoftcapAmount { get; set; }
    
    // Hardcap amount
    [JsonProperty("hardcap_amount")]
    public decimal? HardcapAmount { get; set; }
    
    // Total raised
    [JsonProperty("total_raised")]
    public decimal? TotalRaised { get; set; }
    
    // Quote pre-sale currency
    [JsonProperty("quote_pre_sale_currency")]
    public string QuotePreSaleCurrency { get; set; } = string.Empty;
    
    // Base pre sale amount
    [JsonProperty("base_pre_sale_amount")]
    public string BasePreSaleAmount { get; set; } = string.Empty;
    
    // Quote pre sale amount
    [JsonProperty("quote_pre_sale_amount")]
    public decimal? QuotePreSaleAmount { get; set; }
    
    // Quote public sale currency
    [JsonProperty("quote_public_sale_currency")]
    public string QuotePublicSaleCurrency { get; set; } = string.Empty;
    
    // Base public sale amount
    [JsonProperty("base_public_sale_amount")]
    public decimal? BasePublicSaleAmount { get; set; }
    
    // Quote public sale amount
    [JsonProperty("quote_public_sale_amount")]
    public decimal? QuotePublicSaleAmount { get; set; }
    
    // Accepting currencies
    [JsonProperty("accepting_currencies")]
    public string AcceptingCurrencies { get; set; } = string.Empty;
    
    // Country origin
    [JsonProperty("country_origin")]
    public string CountryOrigin { get; set; } = string.Empty;
    
    // Pre sale start date
    [JsonProperty("pre_sale_start_date")]
    public DateTime? PreSaleStartDate { get; set; }
    
    // Pre sale end date
    [JsonProperty("pre_sale_end_date")]
    public DateTime? PreSaleEndDate { get; set; }
    
    // Whitelist url
    [JsonProperty("whitelist_url")]
    public string WhitelistUrl { get; set; } = string.Empty;
    
    // Whitelist start date
    [JsonProperty("whitelist_start_date")]
    public DateTime? WhitelistStartDate { get; set; }
    
    // Whitelist end date
    [JsonProperty("whitelist_end_date")]
    public DateTime? WhitelistEndDate { get; set; }
    
    // Bounty detail url
    [JsonProperty("bounty_detail_url")]
    public string BountyDetailUrl { get; set; } = string.Empty;
    
    // Amount for sale
    [JsonProperty("amount_for_sale")]
    public decimal? AmountForSale { get; set; }
    
    // KYC required
    [JsonProperty("kyc_required")]
    public bool KycRequired { get; set; }
    
    // Whitelist available
    [JsonProperty("whitelist_available")]
    public bool? WhitelistAvailable { get; set; }
    
    // Pre sale ended
    [JsonProperty("pre_sale_ended")] 
    public bool PreSaleEnded { get; set; }
}