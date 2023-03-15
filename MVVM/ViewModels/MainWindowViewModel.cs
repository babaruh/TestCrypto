using System.Windows.Input;
using TestCrypto.Core;
using TestCrypto.Services;

namespace TestCrypto.MVVM.ViewModels;

public class MainWindowViewModel : Core.ViewModel
{
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

    public ICommand NavigateExploreViewCommand { get; set; }
    public ICommand NavigateExchangeViewCommand { get; set; }
    public ICommand NavigateSupportViewCommand { get; set; }

    public MainWindowViewModel(INavigationService navigationService)
    {
        Navigation = navigationService;
        NavigateExploreViewCommand = new RelayCommand(_ => {Navigation.NavigateTo<ExploreViewModel>();}, _ => true);
        NavigateExchangeViewCommand = new RelayCommand(_ => {Navigation.NavigateTo<ExchangesViewModel>();}, _ => true);
        NavigateSupportViewCommand = new RelayCommand(_ => {Navigation.NavigateTo<SupportViewModel>();}, _ => true);
    }
}
