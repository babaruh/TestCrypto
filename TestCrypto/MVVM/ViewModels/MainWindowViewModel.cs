using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestCrypto.Services;

namespace TestCrypto.MVVM.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private INavigationService _navigation;

    public MainWindowViewModel(INavigationService navigationService)
    {
        Navigation = navigationService;
    }

    [RelayCommand]
    public void NavigateExploreView() => Navigation.NavigateTo<ExploreViewModel>();
    
    [RelayCommand]
    public void NavigateExchangesView() => Navigation.NavigateTo<ExchangesViewModel>();
    
    [RelayCommand]
    public void NavigateSupportView() => Navigation.NavigateTo<SupportViewModel>();
}
