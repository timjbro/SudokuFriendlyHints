using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace SudokuFriendlyHints.WPF.View
{
    public class BooleanToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool v))
                throw new ArgumentException($"{nameof(value)} must be a bool.");

            if (!(parameter is string p))
                throw new ArgumentException($"{nameof(parameter)} must be a string.");

            var colors = p.Split('|');
            if (colors.Length != 2)
                throw new ArgumentException($"{nameof(parameter)} must contain two colors separated by a | character.");

            return new BrushConverter().ConvertFromString(v ? colors[0] : colors[1]) as SolidColorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => new NotImplementedException();
    }
}
