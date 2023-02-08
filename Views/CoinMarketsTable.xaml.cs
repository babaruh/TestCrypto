using System.Windows.Controls;
using TestCrypto.ViewModels;

namespace TestCrypto.Views;

public partial class CoinMarketsTable : UserControl
{
    public CoinMarketsTable()
    {
        InitializeComponent();
        DataContext = new CoinMarketViewModel();
    }
}