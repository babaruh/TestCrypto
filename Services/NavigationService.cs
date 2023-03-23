using TestCrypto.Core;

namespace TestCrypto.Services;

public interface INavigationService
{
    ViewModel CurrentView { get; }

    void NavigateTo<TViewModel>() where TViewModel : ViewModel;
    void NavigateTo<TViewModel>(object parameter) where TViewModel : ViewModel;
}

public class NavigationService : ObservableObject, INavigationService
{
    private readonly Func<Type, object?, ViewModel> _viewModelFactory;
    private ViewModel _currentView;
    
    public ViewModel CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public NavigationService(Func<Type, object?, ViewModel> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo<TViewModel>() 
        where TViewModel : ViewModel
    {
        var viewModel = _viewModelFactory.Invoke(typeof(TViewModel), null);
        CurrentView = viewModel;
    }

    public void NavigateTo<TViewModel>(object parameter) 
        where TViewModel : ViewModel
    {
        var viewModel = _viewModelFactory.Invoke(typeof(TViewModel), parameter);
        CurrentView = viewModel;
    }
}