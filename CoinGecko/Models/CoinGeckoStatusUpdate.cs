using Newtonsoft.Json;

namespace CoinGecko.Models;

// Status update
public class CoinGeckoStatusUpdate
{
    // Description
    public string Description { get; set; } = string.Empty;
    
    // Category
    public string Category { get; set; } = string.Empty;
    
    // Created time
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
    
    // User name
    public string User { get; set; } = string.Empty;
    
    // User title
    [JsonProperty("user_title")]
    public string UserTitle { get; set; } = string.Empty;
    
    // Is pinned
    public bool Pin { get; set; }
    
    // Project info
    public CoinGeckoProject? Project { get; set; }
}