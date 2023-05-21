using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using TestCrypto.MVVM.ViewModels;
using TestCrypto.MVVM.Views;
using TestCrypto.Services;

namespace TestCrypto;

public partial class App
{
    private readonly ServiceProvider _serviceProvider;
    private const string SyncfusionLicenseKey = "Mgo+DSMBaFt+QHJqVk1mQ1NEaV1CX2BZf1F8RmVTelZgFChNYlxTR3ZaQFxiS31Vc0xnW31b;Mgo+DSMBPh8sVXJ1S0R+X1pCaV1CQmFJfFBmRGFTfFh6cV1WACFaRnZdQV1mS39SdEZlXHZadHJQ;ORg4AjUWIQA/Gnt2VFhiQlJPcEBAXXxLflF1VWJbdV12flBOcDwsT3RfQF5jTHxSd0dgX3pXdHJWQw==;MjEzNTAyMUAzMjMxMmUzMjJlMzNpQ3V0Mzl5eWM1bmU1SmVLL28yZXBPUndOVlFQcjB1NXB5bzNRZkRNRC9NPQ==;MjEzNTAyMkAzMjMxMmUzMjJlMzNObEFINkNTR0FnaTVCTS9Ubks3R2J2cFhFc3psYWJkbFI1Tm0ydm9lK2hJPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfVldX2NWfFN0RnNYfVRzcl9DaEwxOX1dQl9gSXtRd0RhWnlbeX1TRGU=;MjEzNTAyNEAzMjMxMmUzMjJlMzNSUU1VSFJ4MUdOUUZUSkRQRFdwckR1VU5ZM3dNaTNHZC90QTVuNHpyOG1NPQ==;MjEzNTAyNUAzMjMxMmUzMjJlMzNGUzFBTCttWUVnYnFDNkI4RXBvZmFPSlRHYWJhSjNBUnZQeXlzOXpYWXFFPQ==;Mgo+DSMBMAY9C3t2VFhiQlJPcEBAXXxLflF1VWJbdV12flBOcDwsT3RfQF5jTHxSd0dgXn9ecHZSQw==;MjEzNTAyN0AzMjMxMmUzMjJlMzNYajB3RG85eGMwVlkxSUFneEQ2MDhHbzRHbXpWL0Ftdi9TYmNUc0NxamswPQ==;MjEzNTAyOEAzMjMxMmUzMjJlMzNXeXkxdTZKRXhxZTFWcnh4d1UwZFBlbjNJbHg0c3laWGdZNVVZTFVmWUM4PQ==;MjEzNTAyOUAzMjMxMmUzMjJlMzNSUU1VSFJ4MUdOUUZUSkRQRFdwckR1VU5ZM3dNaTNHZC90QTVuNHpyOG1NPQ==";


    public App()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<MainWindow>(provider => new MainWindow
        {
            DataContext = provider.GetRequiredService<MainWindowViewModel>()
        });
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<ExploreViewModel>();
        services.AddSingleton<ExchangesViewModel>();
        services.AddSingleton<CoinFullDataViewModel>();
        services.AddSingleton<SupportViewModel>();
        

        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<Func<Type, object, ObservableObject>>(serviceProvider =>
            (viewModelType, param) => 
            {
                if(param is null) return (ObservableObject)ActivatorUtilities.CreateInstance(serviceProvider, viewModelType);
                var stringParam = (string)param;
                var viewModel = (ObservableObject)ActivatorUtilities.CreateInstance(serviceProvider, viewModelType, stringParam);
                return viewModel;
            });

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncfusionLicenseKey);
            
        base.OnStartup(e);
    }
}