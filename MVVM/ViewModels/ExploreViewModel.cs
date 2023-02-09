using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestCrypto.Clients;
using TestCrypto.Clients.CoinGecko;
using TestCrypto.MVVM.Models;

namespace TestCrypto.MVVM.ViewModels;

public class ExploreViewModel : Core.ViewModel
{
    private ObservableCollection<CoinMarket> _coinMarkets;
    private readonly CoinsClient _coinsClient;

    public ObservableCollection<CoinMarket> CoinMarkets
    {
        get => _coinMarkets;
        private set
        {
            _coinMarkets = value;
            OnPropertyChanged();
        }
    }

    public ExploreViewModel()
    {
        _coinsClient = new CoinsClient(new HttpClient(), new JsonSerializerSettings());
        _coinMarkets = new ObservableCollection<CoinMarket>();
        LoadCoinMarkets();
    }

    private async Task LoadCoinMarkets()
    {
        var cryptoCurrencies = await _coinsClient.GetCoinMarkets("usd");
    
        foreach (var currency in cryptoCurrencies)
        {
            CoinMarkets.Add(currency);
        }
    }
}