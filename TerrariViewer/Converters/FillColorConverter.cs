using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace TerrariViewer.Converters
{
    public class FillColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return new SolidColorBrush((Color)value);
            }
            catch
            {
                return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                SolidColorBrush br = value as SolidColorBrush;
                return Color.FromRgb(br.Color.R, br.Color.G, br.Color.B);
            }
            catch
            {
                return Colors.Black;
            }
        }
    }
}
