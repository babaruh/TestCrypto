using System.Windows;
using System.Windows.Controls;
using TestCrypto.MVVM.Models;
using TestCrypto.MVVM.ViewModels;

namespace TestCrypto.MVVM.Views;

public partial class ExploreView : UserControl
{
    public ExploreView()
    {
        InitializeComponent();
    }

    private void DataGrid_DoubleClick(object sender, RoutedEventArgs e)
    {
        var dataGrid = sender as DataGrid;
        if (dataGrid?.SelectedItem is not CoinMarket item) return;
        
        var id = item.Id;
        var viewModel = DataContext as ExploreViewModel;
        viewModel?.NavigateCoinFullDataViewCommand.Execute(id);
    }
}