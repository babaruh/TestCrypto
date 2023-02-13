using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestCrypto.MVVM.Models;

namespace TestCrypto.Clients.CoinGecko;

public class ExchangesClient : BaseApiClient
{
    public static readonly string Exchanges = "exchanges";

    public ExchangesClient(HttpClient httpClient, JsonSerializerSettings serializerSettings) 
        : base(httpClient, serializerSettings)
    {
    }
    
    public async Task<IReadOnlyList<Exchange>> GetExchanges() => await GetExchanges(20, "").ConfigureAwait(false);

    public async Task<IReadOnlyList<Exchange>> GetExchanges(
        int perPage,
        string page)
    {
        return await GetAsync<IReadOnlyList<Exchange>>(AppendQueryString(Exchanges, new Dictionary<string, object>
        {
            {
                "per_page",
                (object) perPage
            },
            {
                nameof (page),
                (object) page
            }
        })).ConfigureAwait(false);
    }
}