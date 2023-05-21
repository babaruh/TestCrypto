using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TestCrypto.Services;

public interface INavigationService
{
    ObservableObject CurrentView { get; }

    void NavigateTo<TViewModel>() where TViewModel : ObservableObject;
    void NavigateTo<TViewModel>(object parameter) where TViewModel : ObservableObject;
}

public class NavigationService : ObservableObject, INavigationService
{
    private readonly Func<Type, object?, ObservableObject> _viewModelFactory;
    private ObservableObject _currentView;
    
    public ObservableObject CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public NavigationService(Func<Type, object?, ObservableObject> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo<TViewModel>() 
        where TViewModel : ObservableObject
    {
        var viewModel = _viewModelFactory.Invoke(typeof(TViewModel), null);
        CurrentView = viewModel;
    }

    public void NavigateTo<TViewModel>(object parameter) 
        where TViewModel : ObservableObject
    {
        var viewModel = _viewModelFactory.Invoke(typeof(TViewModel), parameter);
        CurrentView = viewModel;
    }
}