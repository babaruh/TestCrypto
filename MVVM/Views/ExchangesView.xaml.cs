using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using TestCrypto.MVVM.Models;

namespace TestCrypto.MVVM.Views;

public partial class ExchangesView : UserControl
{
    public ExchangesView()
    {
        InitializeComponent();
    }

    public void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var row = (DataGridRow)sender;
        var url = ((Exchange)row.Item).Url;
        
        var browserPath = GetBrowserPath();
        if (browserPath == string.Empty)
            browserPath = "iexplore";
        
        var process = new Process();
        
        process.StartInfo = new ProcessStartInfo(browserPath);
        process.StartInfo.Arguments = url;
        
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