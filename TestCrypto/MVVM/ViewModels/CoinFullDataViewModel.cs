using System.Diagnostics;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using CoinGecko.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestCrypto.MVVM.ViewModels;

public partial class CoinFullDataViewModel : ObservableObject
{
    private readonly string _id;
    private readonly ICoinGeckoClient _coinsClient;
    
    [ObservableProperty]
    private CoinGeckoTicker _selectedTicker;
    
    [ObservableProperty]
    private CoinGeckoAssetDetails? _coinFullData;

    public CoinFullDataViewModel(string id)
    {
        _id = id;
        _coinsClient = new CoinGeckoClient();
        LoadCoinFullData();
    }

    private async void LoadCoinFullData()
    {
        CoinFullData = await _coinsClient.GetAssetDetailsAsync(_id, null, true, true, null, null, true);
    }

    [RelayCommand]
    private void OpenLink(object parameter)
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