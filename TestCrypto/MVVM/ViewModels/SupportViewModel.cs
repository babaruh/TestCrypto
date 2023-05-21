using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestCrypto.MVVM.ViewModels;

public partial class SupportViewModel : ObservableObject
{
    private readonly RelayCommand _openLinkCommand;
    public string GithubUrl => "https://github.com/babaruh/TestCrypto";
    public string LearnWpfUrl => "https://learn.microsoft.com/en-us/dotnet/desktop/wpf";
    public string MailUrl => "https://mail.google.com";

    
    [RelayCommand]
    private static void OpenLink(object parameter)
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