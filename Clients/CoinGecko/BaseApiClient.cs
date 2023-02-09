using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestCrypto.Clients.CoinGecko;

public class BaseApiClient
{
    private static readonly Uri CoinGeckoApiEndPoint = new("https://api.coingecko.com/api/v3/");

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerSettings _serializerSettings;

    public BaseApiClient(HttpClient httpClient, JsonSerializerSettings serializerSettings)
    {
        _httpClient = httpClient;
        _serializerSettings = serializerSettings;
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

    public Uri AppendQueryString(string path, Dictionary<string, object> parameter) => CreateUrl(path, parameter);

    public Uri AppendQueryString(string path) => CreateUrl(path, new Dictionary<string, object>());

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