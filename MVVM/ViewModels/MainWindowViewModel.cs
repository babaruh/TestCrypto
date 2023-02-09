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

    public RelayCommand NavigateExploreViewCommand { get; set; }
    public RelayCommand NavigateExchangeViewCommand { get; set; }
    public RelayCommand NavigateSettingsViewCommand { get; set; }
    public RelayCommand NavigateSupportViewCommand { get; set; }

    public MainWindowViewModel(INavigationService navigationService)
    {
        Navigation = navigationService;
        NavigateExploreViewCommand = new RelayCommand(_ => {Navigation.NavigateTo<ExploreViewModel>();}, _ => true);
        NavigateExchangeViewCommand = new RelayCommand(_ => {Navigation.NavigateTo<ExchangesViewModel>();}, _ => true);
        NavigateSettingsViewCommand = new RelayCommand(_ => {Navigation.NavigateTo<SettingsViewModel>();}, _ => true);
        NavigateSupportViewCommand = new RelayCommand(_ => {Navigation.NavigateTo<SupportViewModel>();}, _ => true);
    }
}
