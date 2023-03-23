using System.Globalization;
using System.Windows.Data;

namespace TestCrypto.Convertors;

public class NumberToFormattedStringWithCommaConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var number = (decimal)value;
        return $"{number:n2}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var formattedString = (string)value;
        var number = decimal.Parse(formattedString.Replace(",", ""));
        return number;
    }
}