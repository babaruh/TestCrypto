using System.Diagnostics;
using System.Windows.Input;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using CoinGecko.Models;
using TestCrypto.Core;

namespace TestCrypto.MVVM.ViewModels;

public class CoinFullDataViewModel : Core.ViewModel
{
    private readonly string _id;
    private readonly ICoinGeckoClient _coinsClient;
    private readonly RelayCommand _openLinkCommand;
    private CoinGeckoTicker _selectedTicker;
    private CoinGeckoAssetDetails _coinFullData;

    public ICommand OpenLinkCommand => _openLinkCommand;
    
    public CoinGeckoTicker SelectedTicker
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
        _coinsClient = new CoinGeckoClient();
        LoadCoinFullData();
        
        _openLinkCommand = new RelayCommand(OpenLink, _ => true);
    }

    public CoinGeckoAssetDetails CoinFullData
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
        CoinFullData = await _coinsClient.GetAssetDetailsAsync(_id, null, true, true, null, null, true);
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