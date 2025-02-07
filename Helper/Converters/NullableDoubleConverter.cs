using System.Windows;
using System.Windows.Data;

namespace MFAWPF.Utils.Converters;

public class NullableDoubleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value == null)
            return string.Empty;
        return value.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
        var strValue = value as string;
        if (string.IsNullOrWhiteSpace(strValue))
            return null;
        if (double.TryParse(strValue, out var result))
            return result;
        return DependencyProperty.UnsetValue;
    }
}