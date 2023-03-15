using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using TestCrypto.Clients;
using TestCrypto.Clients.CoinGecko;
using TestCrypto.Core;
using TestCrypto.MVVM.Models;
using TestCrypto.MVVM.Views;
using TestCrypto.Services;

namespace TestCrypto.MVVM.ViewModels;

public class ExploreViewModel : Core.ViewModel
{
    private readonly CoinsClient _coinsClient;
    private INavigationService _navigation;
    private ObservableCollection<CoinMarket> _coinMarkets;
    private CoinMarket _selectedCoinMarket;

    public ObservableCollection<CoinMarket> CoinMarkets
    {
        get => _coinMarkets;
        private set
        {
            _coinMarkets = value;
            OnPropertyChanged();
        }
    }

    public CoinMarket SelectedCoinMarket
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
        
        _coinsClient = new CoinsClient(new HttpClient(), new JsonSerializerSettings());
        _coinMarkets = new ObservableCollection<CoinMarket>();
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
        var cryptoCurrencies = await _coinsClient.GetCoinMarkets("usd");
    
        foreach (var currency in cryptoCurrencies) 
            CoinMarkets.Add(currency);
    }
}