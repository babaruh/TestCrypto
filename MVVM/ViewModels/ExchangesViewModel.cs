using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using TestCrypto.Clients.CoinGecko;
using TestCrypto.Core;
using TestCrypto.MVVM.Models;
using TestCrypto.Services;

namespace TestCrypto.MVVM.ViewModels;

public class ExchangesViewModel : Core.ViewModel
{
    private ObservableCollection<Exchange> _exchanges;
    private readonly ExchangesClient _exchangesClient;
    private readonly RelayCommand _openLinkCommand;
    private Exchange _selectedExchange;

    public ICommand OpenLinkCommand => _openLinkCommand;
    
    public ObservableCollection<Exchange> Exchanges
    {
        get => _exchanges;
        set
        {
            _exchanges = value;
            OnPropertyChanged();
        }
    }

    public Exchange SelectedExchange
    {
        get => _selectedExchange;
        set
        {
            _selectedExchange = value;
            OnPropertyChanged();
        }
    }

    public ExchangesViewModel()
    {
        _exchangesClient = new ExchangesClient(new HttpClient(), new JsonSerializerSettings());
        _exchanges = new ObservableCollection<Exchange>();
        LoadExchanges();

        _openLinkCommand = new RelayCommand(OpenLink, _ => true);
    }
    
    private async Task LoadExchanges()
    {
        var cryptoCurrencies = await _exchangesClient.GetExchanges();

        foreach (var currency in cryptoCurrencies) 
            Exchanges.Add(currency);
    }

    private static void OpenLink(object parameter)
    {
        if (parameter is not string url) 
            return;
        
        var sInfo = new ProcessStartInfo(url)
        {
            UseShellExecute = true
        };

        Process.Start(sInfo);
    }
}
