using System.Collections.ObjectModel;
using System.Diagnostics;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using CoinGecko.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestCrypto.MVVM.ViewModels;

public partial class ExchangesViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<CoinGeckoExchange> _exchanges;
    
    [ObservableProperty]
    private CoinGeckoExchange _selectedExchange;
    
    private readonly ICoinGeckoClient _exchangesClient;

    public ExchangesViewModel()
    {
        _exchangesClient = new CoinGeckoClient();
        _exchanges = new ObservableCollection<CoinGeckoExchange>();
        LoadExchanges();
    }
    
    private async void LoadExchanges()
    {
        var exchanges = await _exchangesClient.GetExchangesAsync(null, 10);

        Exchanges = new ObservableCollection<CoinGeckoExchange>(exchanges);
    }

    [RelayCommand]
    private void OpenLink(object parameter)
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
