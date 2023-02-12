using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Win32;
using TestCrypto.MVVM.Models;
using TestCrypto.MVVM.ViewModels;

namespace TestCrypto.MVVM.Views;

public partial class CoinFullDataView : UserControl
{
    public CoinFullDataView()
    {
        InitializeComponent();
    }

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        var browserPath = GetBrowserPath();
        if (browserPath == string.Empty)
            browserPath = "iexplore";
        
        var process = new Process();
        
        process.StartInfo = new ProcessStartInfo(browserPath);
        process.StartInfo.Arguments = e.Uri.AbsoluteUri;

        process.Start();
        e.Handled = true;
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var browserPath = GetBrowserPath();
        if (browserPath == string.Empty)
            browserPath = "iexplore";
        
        var process = new Process();
        
        process.StartInfo = new ProcessStartInfo(browserPath);
        
        var button = sender as Button;
        process.StartInfo.Arguments = button.CommandParameter as string;

        process.Start();
    }
    
    private static string GetBrowserPath()
    {
        var browser = string.Empty;
        RegistryKey key = null;

        try
        {
            // try location of default browser path in XP
            key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

            // try location of default browser path in Vista
            if (key == null)
            {
                key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false); ;
            }

            if (key != null)
            {
                //trim off quotes
                browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");
                if (!browser.EndsWith("exe"))
                {
                    //get rid of everything after the ".exe"
                    browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4);
                }

                key.Close();
            }
        }
        catch
        {
            return string.Empty;
        }

        return browser;
    }
}