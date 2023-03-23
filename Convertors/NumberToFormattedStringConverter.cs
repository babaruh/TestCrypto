using System.Globalization;
using System.Windows.Data;

namespace TestCrypto.Convertors;

public class NumberToFormattedStringConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return "∞";
        
        var number = (decimal)value;
        return number switch
        {
            >= 1000000000000 => (number / 1000000000000).ToString("0.##") + "T",
            >= 1000000000 => (number / 1000000000).ToString("0.##") + "B",
            >= 1000000 => (number / 1000000).ToString("0.##") + "M",
            >= 1000 => (number / 1000).ToString("0.##") + "K",
            _ => number.ToString("0.##")
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var strValue = (string)value;
        decimal result;
        var multiplier = 1m;
        var lastChar = strValue[^1];

        switch (lastChar)
        {
            case 'T':
                multiplier = 1000000000000m;
                break;
            case 'B':
                multiplier = 1000000000m;
                break;
            case 'M':
                multiplier = 1000000m;
                break;
            case 'K':
                multiplier = 1000m;
                break;
        }

        if (multiplier != 1)
        {
            strValue = strValue.Substring(0, strValue.Length - 1);
        }

        if (decimal.TryParse(strValue, out result))
        {
            return result * multiplier;
        }

        return null;
    }
}


