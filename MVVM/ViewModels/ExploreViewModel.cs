using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
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
    private ObservableCollection<CoinMarket> _coinMarkets;
    public ObservableCollection<CoinMarket> CoinMarkets
    {
        get => _coinMarkets;
        private set
        {
            _coinMarkets = value;
            OnPropertyChanged();
        }
    }

    private INavigationService _navigation;

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }
    
    public RelayCommand NavigateCoinFullDataViewCommand { get; set; }

    public ExploreViewModel(INavigationService navigation)
    {
        Navigation = navigation;
        NavigateCoinFullDataViewCommand = 
            new RelayCommand(ShowDetailExecute, o => true); 
        
        _coinsClient = new CoinsClient(new HttpClient(), new JsonSerializerSettings());
        _coinMarkets = new ObservableCollection<CoinMarket>();
        LoadCoinMarkets();
    }
    
    private void ShowDetailExecute(object? parameter)
    {
        var id = (string)parameter;
        Navigation.NavigateTo<CoinFullDataViewModel>(id);
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