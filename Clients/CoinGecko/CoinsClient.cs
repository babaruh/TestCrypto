using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestCrypto.MVVM.Models;

namespace TestCrypto.Clients.CoinGecko;

public class CoinsClient : BaseApiClient
{
    private static readonly string CoinsMarketsApi = "coins/markets";
    
    public CoinsClient(HttpClient httpClient, JsonSerializerSettings serializerSettings)
        :base(httpClient, serializerSettings)
    {
    }
    
    public async Task<List<CoinMarket>> GetCoinMarkets(string vsCurrency)
    {
        return await GetCoinMarkets(vsCurrency,
            Array.Empty<string>(), null, 10, new int?(), false, null, null).ConfigureAwait(false);
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

    
}