using CoinGecko.Interfaces;
using CoinGecko.Models;
using Newtonsoft.Json;

namespace CoinGecko.Clients;

public class CoinGeckoClient : ICoinGeckoClient
{
    private readonly string _baseAddress = "https://api.coingecko.com/api/v3/";
    
    public async Task<string> PingAsync()
    {
        var parameters = new Dictionary<string, object>();
        var result = await GetAsync<Dictionary<string, string>>(CreateUrl(GetUrl("ping"), parameters));

        return result!.First(k => k.Key == "gecko_says").Value;
    }

    public async Task<IEnumerable<CoinGeckoMarket>?> GetMarketsAsync(
        string quoteAsset,
        IEnumerable<string>? assetIds = null, 
        string? category = null, 
        string? order = null,
        int? page = null, 
        int? pageSize = null, 
        bool? sparkline = null, 
        string? priceChangePercentages = null)
    {
        var parameters = new Dictionary<string, object>();
        parameters.AddParameter("vs_currency", quoteAsset);
        parameters.AddOptionalParameter("ids", assetIds == null ? null : string.Join(",", assetIds));
        parameters.AddOptionalParameter("category", category);
        parameters.AddOptionalParameter("order", order);
        parameters.AddOptionalParameter("per_page", pageSize);
        parameters.AddOptionalParameter("page", page);
        parameters.AddOptionalParameter("sparkline", sparkline);
        parameters.AddOptionalParameter("price_change_percentage", priceChangePercentages == null ? null : string.Join(", ", priceChangePercentages));

        return await GetAsync<IEnumerable<CoinGeckoMarket>>(CreateUrl(GetUrl("coins/markets/"), parameters));
    }

    public async Task<CoinGeckoAssetDetails?> GetAssetDetailsAsync(
        string assetId, 
        bool? localization = null, 
        bool? tickers = null, 
        bool? marketData = null,
        bool? communityData = null, 
        bool? developerData = null, 
        bool? sparkline = null)
    {
        var parameters = new Dictionary<string, object>();
        
        parameters.AddOptionalParameter("localization", localization);
        parameters.AddOptionalParameter("tickers", tickers);
        parameters.AddOptionalParameter("market_data", marketData);
        parameters.AddOptionalParameter("community_data", communityData);
        parameters.AddOptionalParameter("developer_data", developerData);
        parameters.AddOptionalParameter("sparkline", sparkline);
        
        return await GetAsync<CoinGeckoAssetDetails>(CreateUrl(GetUrl("coins/" + assetId), parameters));
    }

    public Task<IEnumerable<CoinGeckoExchange>?> GetExchangesAsync(int? page = null, int? pageSize = null)
    {
        var parameters = new Dictionary<string, object>();
        
        parameters.AddOptionalParameter("page", page);
        parameters.AddOptionalParameter("per_page", pageSize);

        return GetAsync<IEnumerable<CoinGeckoExchange>>(CreateUrl(GetUrl("exchanges/"), parameters));
    }


    // Creates a URI from a base address and a dictionary of query parameters
    private static Uri CreateUrl(
        string baseAddress, 
        Dictionary<string, object>? parameter)
    {
        if (!Uri.IsWellFormedUriString(baseAddress, UriKind.Absolute))
            throw new ArgumentException("Invalid base address");

        if (parameter == null || parameter.Count == 0)
            return new Uri(baseAddress); 

        var queryString = string.Join("&", parameter.Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value.ToString() ?? string.Empty)}"));
        
        var fullAddress = $"{baseAddress}?{queryString}";
        
        return new Uri(fullAddress.ToLower());
    }
    
    // Performs an asynchronous HTTP GET request to a given resource URI and return the deserialized data of type T
    private static async Task<T?> GetAsync<T>(Uri resourceUri)
    {
        if (resourceUri == null)
            throw new ArgumentNullException(nameof(resourceUri));

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.63 Safari/537.36 Edg/93.0.961.38");

        var response = await client.GetAsync(resourceUri);
        
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<T>(content);

            return data;
        }

        throw new HttpRequestException($"{response.StatusCode}: {response.ReasonPhrase}");
    }
    
    // Get url for an endpoint
    private string GetUrl(string endpoint) => 
        _baseAddress.AppendPath(endpoint);
}