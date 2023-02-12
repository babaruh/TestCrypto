using System;
using System.Globalization;
using System.Windows.Data;

namespace TestCrypto.Convertors;

public class DecimalToFormattedPercentageStringConvertor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var percentage = (decimal)value;
        var formattedString = $"{percentage:+0.##;-0.##;0.##}%";

        return formattedString;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var formattedString = (string)value;
        var percentage = decimal.Parse(formattedString.Replace("%", ""));
        return percentage;
    }
}