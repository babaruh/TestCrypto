namespace CoinGecko.Models;

/// Project info
public class CoinGeckoProject
{
    /// Type
    public string Type { get; set; } = string.Empty;
    
    /// Id
    public string Id { get; set; } = string.Empty;
    
    /// Name
    public string Name { get; set; } = string.Empty;
    
    /// Images
    public CoinGeckoImages? Image { get; set; }
}