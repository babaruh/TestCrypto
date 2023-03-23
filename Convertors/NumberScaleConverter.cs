using System.Globalization;
using System.Windows.Data;

namespace TestCrypto.Convertors;

public class NumberScaleConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return "∞";
        
        var number = (decimal)value;
        return number switch
        {
            >= 1_000_000_000_000 => (number / 1_000_000_000_000).ToString("0.##") + "T",
            >= 1_000_000_000 => (number / 1_000_000_000).ToString("0.##") + "B",
            >= 1_000_000 => (number / 1_000_000).ToString("0.##") + "M",
            >= 1_000 => (number / 1_000).ToString("0.##") + "K",
            _ => number.ToString("0.##")
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var stringValue = (string)value;
        var suffixes = new Dictionary<string, decimal>
        {
            { "T", 1_000_000_000_000m },
            { "B", 1_000_000_000m },
            { "M", 1_000_000m },
            { "K", 1_000m }
        };
        return decimal.TryParse(stringValue[..^1], out var result) ? result * suffixes[stringValue] : null;
    }
}


