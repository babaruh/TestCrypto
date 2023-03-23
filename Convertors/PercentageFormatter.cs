using System.Globalization;
using System.Windows.Data;
using System.Windows.Documents;

namespace TestCrypto.Convertors;

public class PercentageFormatter : IValueConverter 
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not (double or decimal)) 
            throw new ArgumentException("Value must be double or decimal");
        
        var formattedString = $"{value:+0.##;-0.##;0.##}%";
        return formattedString;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var formattedString = (string)value;
        var percentageString = formattedString.TrimEnd('%');
        var percentage = decimal.Parse(percentageString);
        return percentage;
    }
}