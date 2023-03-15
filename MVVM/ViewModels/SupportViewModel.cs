using System.Diagnostics;
using System.Windows.Input;
using TestCrypto.Core;

namespace TestCrypto.MVVM.ViewModels;

public class SupportViewModel : Core.ViewModel
{
    private readonly RelayCommand _openLinkCommand;
    public string GithubUrl => "https://github.com/babaruh/TestCrypto";
    public string LearnWpfUrl => "https://learn.microsoft.com/en-us/dotnet/desktop/wpf";
    public string MailUrl => "https://mail.google.com";

    public ICommand OpenLinkCommand => _openLinkCommand;

    public SupportViewModel()
    {
        _openLinkCommand = new RelayCommand(OpenLink, _ => true);
    }
    
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