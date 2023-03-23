using System.Globalization;
using System.Windows.Data;

namespace TestCrypto.Convertors;

public class NumberFormatter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not (double or decimal)) 
            throw new ArgumentException("Value must be double or decimal");
        
        return $"{value:n2}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var formattedString = (string)value;
        var number = decimal.Parse(formattedString);
        return number;
    }
}