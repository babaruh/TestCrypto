using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using TestCrypto.Clients.CoinGecko;
using TestCrypto.MVVM.Models;
using TestCrypto.Services;

namespace TestCrypto.MVVM.ViewModels;

public class ExchangesViewModel : Core.ViewModel
{
    private ObservableCollection<Exchange> _exchanges;
    private readonly ExchangesClient _exchangesClient;
    
    public ObservableCollection<Exchange> Exchanges
    {
        get => _exchanges;
        private set
        {
            _exchanges = value;
            OnPropertyChanged();
        }
    }

    public ExchangesViewModel()
    {
        _exchangesClient = new ExchangesClient(new HttpClient(), new JsonSerializerSettings());
        _exchanges = new ObservableCollection<Exchange>();
        LoadExchanges();
    }

    private async Task LoadExchanges()
    {
        var cryptoCurrencies = await _exchangesClient.GetExchanges();
    
        foreach (var currency in cryptoCurrencies)
        {
            Exchanges.Add(currency);
        }
    }
}