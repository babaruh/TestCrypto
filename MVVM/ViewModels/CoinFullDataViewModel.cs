using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Input;
using Newtonsoft.Json;
using TestCrypto.Clients.CoinGecko;
using TestCrypto.Core;
using TestCrypto.MVVM.Models;

namespace TestCrypto.MVVM.ViewModels;

public class CoinFullDataViewModel : Core.ViewModel
{
    private readonly string _id;
    private readonly CoinsClient _coinsClient;
    private readonly RelayCommand _openLinkCommand;
    private Ticker _selectedTicker;
    private CoinFullData _coinFullData;

    public ICommand OpenLinkCommand => _openLinkCommand;
    
    public Ticker SelectedTicker
    {
        get => _selectedTicker;
        set
        {
            _selectedTicker = value;
            OnPropertyChanged();
        }
    }

    public CoinFullDataViewModel(string id)
    {
        _id = id;
        _coinsClient = new(new HttpClient(), new JsonSerializerSettings());
        LoadCoinFullData();
        
        _openLinkCommand = new RelayCommand(OpenLink, _ => true);
    }

    public CoinFullData CoinFullData
    {
        get => _coinFullData;
        set
        {
            _coinFullData = value;
            OnPropertyChanged();
        }
    }

    private async void LoadCoinFullData()
    {
        CoinFullData = await _coinsClient.GetAllCoinDataWithId(_id);
    }

    private static void OpenLink(object parameter)
    {
        if(parameter is not string link)
            return;
            
        var sInfo = new ProcessStartInfo(link)
        {
            UseShellExecute = true,
        };
        
        Process.Start(sInfo);
    }
}