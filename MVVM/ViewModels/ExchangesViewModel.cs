using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using Console;
using Newtonsoft.Json;
using TestCrypto.Core;

namespace TestCrypto.MVVM.ViewModels;

public class ExchangesViewModel : Core.ViewModel
{
    private ObservableCollection<CoinGeckoExchange> _exchanges;
    private readonly ICoinGeckoClient _exchangesClient;
    private readonly RelayCommand _openLinkCommand;
    private CoinGeckoExchange _selectedExchange;

    public ICommand OpenLinkCommand => _openLinkCommand;
    
    public ObservableCollection<CoinGeckoExchange> Exchanges
    {
        get => _exchanges;
        set
        {
            _exchanges = value;
            OnPropertyChanged();
        }
    }

    public CoinGeckoExchange SelectedExchange
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
        _exchangesClient = new CoinGeckoClient();
        _exchanges = new ObservableCollection<CoinGeckoExchange>();
        LoadExchanges();

        _openLinkCommand = new RelayCommand(OpenLink, _ => true);
    }
    
    private async Task LoadExchanges()
    {
        var exchanges = await _exchangesClient.GetExchangesAsync(null, 10);

        Exchanges = new ObservableCollection<CoinGeckoExchange>(exchanges);
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
