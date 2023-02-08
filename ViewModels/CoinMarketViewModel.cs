using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestCrypto.Clients;
using TestCrypto.Models;
using TestCrypto.Views;

namespace TestCrypto.ViewModels;

public class CoinMarketViewModel : ViewModelBase
{
    private ObservableCollection<CoinMarket> _coinMarkets;
    private readonly CoinGeckoClient _coinGeckoClient;

    private readonly MainWindowViewModel _mainWindowViewModel;

    public ObservableCollection<CoinMarket> CoinMarkets
    {
        get => _coinMarkets;
        set
        {
            _coinMarkets = value;
            OnPropertyChanged();
        }
    }

    public CoinMarketViewModel()
    {
        _coinGeckoClient = new CoinGeckoClient(new HttpClient(), new JsonSerializerSettings());
        _coinMarkets = new ObservableCollection<CoinMarket>();
        LoadCoinMarkets();
    }

    private async Task LoadCoinMarkets()
    {
        var cryptoCurrencies = await _coinGeckoClient.GetCoinMarkets("usd");
    
        foreach (var currency in cryptoCurrencies)
        {
            CoinMarkets.Add(currency);
        }
    }
}
