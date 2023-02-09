using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TestCrypto.Core;
using TestCrypto.MVVM.ViewModels;
using TestCrypto.MVVM.Views;
using TestCrypto.Services;

namespace TestCrypto;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<MainWindow>(provider => new MainWindow()
        {
            DataContext = provider.GetRequiredService<MainWindowViewModel>()
        });
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<ExploreViewModel>();
        services.AddSingleton<ExchangesViewModel>();
        services.AddSingleton<SettingsViewModel>();
        services.AddSingleton<SupportViewModel>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<Func<Type, ViewModel>>(serviceProvider =>
            viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
            
        base.OnStartup(e);
    }
}