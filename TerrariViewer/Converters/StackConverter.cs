using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TerrariViewer.TerrariaObjects;
using System.Windows.Data;

namespace TerrariViewer.Converters
{
    public class StackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                int stack = (int)value;
                if (stack < 1)
                {
                    return "";
                }
                else
                {
                    return stack;
                }
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
