using System.Collections.ObjectModel;
using System.Windows.Input;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using CoinGecko.Models;
using TestCrypto.Core;
using TestCrypto.Services;

namespace TestCrypto.MVVM.ViewModels;

public class ExploreViewModel : Core.ViewModel
{
    private readonly ICoinGeckoClient _coinsClient;
    private INavigationService _navigation;
    private ObservableCollection<CoinGeckoMarket> _coinMarkets;
    private CoinGeckoMarket _selectedCoinMarket;

    public ObservableCollection<CoinGeckoMarket> CoinMarkets
    {
        get => _coinMarkets;
        private set
        {
            _coinMarkets = value;
            OnPropertyChanged();
        }
    }

    public CoinGeckoMarket SelectedCoinMarket
    {
        get => _selectedCoinMarket;
        set
        {
            _selectedCoinMarket = value;
            OnPropertyChanged();
        }
    }

    public INavigationService Navigation
    {
        get => _navigation;
        private set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand NavigateCoinFullDataViewCommand { get; set; }

    public ExploreViewModel(INavigationService navigation)
    {
        Navigation = navigation;
        NavigateCoinFullDataViewCommand = 
            new RelayCommand(NavigateCoinFullDataView, _ => true); 
        
        _coinsClient = new CoinGeckoClient();
        _coinMarkets = new ObservableCollection<CoinGeckoMarket>();
        LoadCoinMarkets();
    }
    
    private void NavigateCoinFullDataView(object parameter)
    {
        if (parameter is not string id)
            return;

        Navigation.NavigateTo<CoinFullDataViewModel>(id);
    }
    
    private async Task LoadCoinMarkets()
    {
        var cryptoCurrencies = await _coinsClient.GetMarketsAsync("usd", null, null, null, null, 10, true, "1h,24h,7d");

        CoinMarkets = new ObservableCollection<CoinGeckoMarket>(cryptoCurrencies);
    }
}