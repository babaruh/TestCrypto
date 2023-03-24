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

        services.AddSingleton<Func<Type, object, ViewModel>>(serviceProvider =>
            (viewModelType, param) => 
            {
                if(param is null) return (ViewModel)ActivatorUtilities.CreateInstance(serviceProvider, viewModelType);
                var stringParam = (string)param;
                var viewModel = (ViewModel)ActivatorUtilities.CreateInstance(serviceProvider, viewModelType, stringParam);
                return viewModel;
            });

        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(" Mgo+DSMBaFt+QHFqVkNrWE5GdEBAXWFKbld8RWNTfFZgFChNYlxTR3ZcQF5iT39Vc0xiWHZc;Mgo+DSMBPh8sVXJ1S0d+X1RPckBAX3xLflF1VWdTf156d11WACFaRnZdQV1gS31ScERlXHZfc3BX;ORg4AjUWIQA/Gnt2VFhhQlJBfVtdX2FWfFN0RnNddV5wflZOcDwsT3RfQF5jSnxQd0NiX3pXcXFURA==;MTQ0MjYzOEAzMjMxMmUzMTJlMzMzNWRLNU82MDBldzBEUTZ6d25hQkdta0VZTTI2dFdncUhXRmZrdVZtK0c2VmM9;MTQ0MjYzOUAzMjMxMmUzMTJlMzMzNWgrWVhCRkVvMzEvdFlEYU5xb3NwTktsT1ZrcFA5bU9BUmUzbGloNnpiOE09;NRAiBiAaIQQuGjN/V0d+XU9Hc1RGQmFLYVF2R2BJe1RwdF9FaEwxOX1dQl9gSX1RdURlWHlbeXZUT2I=;MTQ0MjY0MUAzMjMxMmUzMTJlMzMzNW14UmQyMUZaYmVVaUo0TE9rQi9sYnhuS3Q4RXlXcVpWU0dTYUVaMnFMQTA9;MTQ0MjY0MkAzMjMxMmUzMTJlMzMzNWFEN24xSm5pRlJtYUh6cmR1dzJRZEU3UER6U3JGR0wwSWlIWU1Vc2NoWkE9;Mgo+DSMBMAY9C3t2VFhhQlJBfVtdX2FWfFN0RnNddV5wflZOcDwsT3RfQF5jSnxQd0NiX3pXc3BTRA==;MTQ0MjY0NEAzMjMxMmUzMTJlMzMzNVJtaFk3cHdpcTMxYlBua0pZaEliWmZHNmFrMjAvR2Y2QXVmd2t4TWtaWlE9;MTQ0MjY0NUAzMjMxMmUzMTJlMzMzNUsrZlJPTWNhZmoyeG9JaDZITHpIdFBCcGswQWdWSmJOVWV5dUtWMUFJOVk9;MTQ0MjY0NkAzMjMxMmUzMTJlMzMzNW14UmQyMUZaYmVVaUo0TE9rQi9sYnhuS3Q4RXlXcVpWU0dTYUVaMnFMQTA9 Hide full key");
        
        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
            
        base.OnStartup(e);
    }
}