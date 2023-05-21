using System.Collections.ObjectModel;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using CoinGecko.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestCrypto.Services;

namespace TestCrypto.MVVM.ViewModels;

public partial class ExploreViewModel : ObservableObject
{
    private readonly ICoinGeckoClient _coinsClient = new CoinGeckoClient();
    
    [ObservableProperty]
    private INavigationService _navigation;
    
    [ObservableProperty]
    private ObservableCollection<CoinGeckoMarket> _coinMarkets= new();
    
    [ObservableProperty]
    private CoinGeckoMarket _selectedCoinMarket;

    
    public ExploreViewModel(INavigationService navigation)
    {
        Navigation = navigation;
        
        LoadCoinMarkets();
    }
    
    [RelayCommand]
    private void NavigateCoinFullDataView(object parameter)
    {
        if (parameter is not string id)
            return;

        Navigation.NavigateTo<CoinFullDataViewModel>(id);
    }
    
    private async void LoadCoinMarkets()
    {
        var cryptoCurrencies = await _coinsClient.GetMarketsAsync("usd", null, null, null, null, 10, true, "1h,24h,7d");

        if (cryptoCurrencies != null) 
            CoinMarkets = new ObservableCollection<CoinGeckoMarket>(cryptoCurrencies);
    }
}