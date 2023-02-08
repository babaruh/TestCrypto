using System;
using System.Globalization;
using System.Windows.Data;

namespace TestCrypto.Convertors;

public class PercentageToFormattedStringAndColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var percentage = (double)value;
        var formattedString = $"{percentage:+0.##;-0.##;0.##}%";

        return formattedString;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var formattedString = (string)value;
        var percentage = double.Parse(formattedString.Replace("%", ""));
        return percentage;
    }
}