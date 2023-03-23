using CoinGecko.Models;
using Console;

namespace CoinGecko.Interfaces;

public interface ICoinGeckoClient
{
    // Ping the server
    Task<string> PingAsync();

    // Get coins market data
    Task<IEnumerable<CoinGeckoMarket>> GetMarketsAsync(
        string quoteAsset, 
        IEnumerable<string>? assetIds = null,
        string? category = null, 
        string? order = null,
        int? page = null, 
        int? pageSize = null, 
        bool? sparkline = null, 
        string priceChangePercentages = null);

    Task<CoinGeckoAssetDetails> GetAssetDetailsAsync(
        string assetId, 
        bool? localization = null, 
        bool? tickers = null, 
        bool? marketData = null, 
        bool? communityData = null, 
        bool? developerData = null, 
        bool? sparkline = null);

    Task<IEnumerable<CoinGeckoExchange>> GetExchangesAsync(
        int? page = null,
        int? pageSize = null);
}