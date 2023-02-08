using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestCrypto.Models;

namespace TestCrypto.Clients;

public class CoinGeckoClient
{
    private static readonly Uri CoinGeckoApiEndPoint = new("https://api.coingecko.com/api/v3/");
    private static readonly string CoinsMarketsApi = "coins/markets";
    private static readonly string SimpleSupportedVsCurrencies = "simple/supported_vs_currencies";
    
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerSettings _serializerSettings;
    public CoinGeckoClient(HttpClient httpClient, JsonSerializerSettings serializerSettings)
    {
        _httpClient = httpClient;
        _serializerSettings = serializerSettings;
    }
    
    public async Task<List<CoinMarket>> GetCoinMarkets(string vsCurrency)
    {
        return await GetCoinMarkets(vsCurrency,
            Array.Empty<string>(), null, 100, new int?(), false, null, null).ConfigureAwait(false);
    }

    public async Task<List<CoinMarket>> GetCoinMarkets(
        string vsCurrency,
        string[] ids,
        string order,
        int? perPage,
        int? page,
        bool sparkline,
        string priceChangePercentage)
    {
        return await GetCoinMarkets(vsCurrency, ids, order, perPage, page, sparkline, priceChangePercentage,
            null).ConfigureAwait(false);
    }
        
    public async Task<List<CoinMarket>> GetCoinMarkets(
        string vsCurrency,
        string[] ids,
        string order,
        int? perPage,
        int? page,
        bool sparkline,
        string priceChangePercentage,
        string? category)
    {
        return await GetAsync<List<CoinMarket>>(AppendQueryString(CoinsMarketsApi, new Dictionary<string, object> 
            { 
                { "vs_currency", 
                    (object) vsCurrency 
                },
                {
                    nameof (ids),
                    (object) string.Join(",", ids)
                },
                {
                    nameof (order),
                    (object) order
                },
                {
                    "per_page",
                    (object) perPage
                },
                {
                    nameof (page),
                    (object) page
                },
                {
                    nameof (sparkline),
                    (object) sparkline
                },
                {
                    "price_change_percentage",
                    (object) priceChangePercentage
                },
                {
                    nameof (category),
                    (object) category
                }
            })).ConfigureAwait(false);
    }

    public async Task<T> GetAsync<T>(Uri resourceUri)
    {
        var httpResponseMessage = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, resourceUri)).ConfigureAwait(false);
        httpResponseMessage.EnsureSuccessStatusCode();
        var str = await httpResponseMessage.Content.ReadAsStringAsync();
        T async;
        try
        {
            async = JsonConvert.DeserializeObject<T>(str, _serializerSettings);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException(ex.Message);
        }
        return async;
    }

    public Uri AppendQueryString(string path, Dictionary<string, object> parameter) => this.CreateUrl(path, parameter);

    public Uri AppendQueryString(string path) => this.CreateUrl(path, new Dictionary<string, object>());

    private Uri CreateUrl(string path, Dictionary<string, object> parameter)
    {
        var source = new List<string>();
        foreach (KeyValuePair<string, object> keyValuePair in parameter)
            source.Add(keyValuePair.Value == null || string.IsNullOrWhiteSpace(keyValuePair.Value.ToString())
                ? (string)null
                : keyValuePair.Key + "=" + keyValuePair.Value.ToString().ToLower(CultureInfo.InvariantCulture));
        var array = source.Where<string>((Func<string, bool>)(x => !string.IsNullOrWhiteSpace(x)))
            .Select<string, string>(new Func<string, string>(WebUtility.HtmlEncode))
            .Select<string, string>((Func<string, int, string>)((x, i) => i <= 0 ? "?" + x : "&" + x))
            .ToArray<string>();
        var relativeUri = array.Length != 0 ? path + string.Join(string.Empty, array) : path;
        return new Uri(CoinGeckoApiEndPoint, relativeUri);
    }
}