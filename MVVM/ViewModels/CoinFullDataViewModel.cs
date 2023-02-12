using System;
using System.Net.Http;
using Newtonsoft.Json;
using TestCrypto.Clients.CoinGecko;
using TestCrypto.Core;
using TestCrypto.MVVM.Models;

namespace TestCrypto.MVVM.ViewModels;

public class CoinFullDataViewModel : Core.ViewModel
{
    private string _id;
    
    private CoinFullData _coinFullData;
    private readonly CoinsClient _coinsClient;

    public CoinFullDataViewModel(string id)
    {
        _id = id;
        _coinsClient = new(new HttpClient(), new JsonSerializerSettings());
        LoadCoinFullData();
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
}