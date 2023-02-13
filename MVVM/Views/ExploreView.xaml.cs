using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key is not Key.Enter) return;
        var textBox = sender as TextBox;

        if(string.IsNullOrWhiteSpace(textBox?.Text)) return;
        
        var text = textBox.Text;
        
        var id = text;
        var viewModel = DataContext as ExploreViewModel;
        viewModel?.NavigateCoinFullDataViewCommand.Execute(id);
    }
}