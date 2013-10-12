using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using TerrariViewer.TerrariaObjects;

namespace TerrariViewer.Converters
{
    public class BuffConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                int val = (int)value;
                return Buff.BuffDictionary[val];
            }
            catch
            {
                return Buff.BuffDictionary[0];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                Buff srcInfo = value as Buff;
                if (srcInfo == null)
                {
                    return 0;
                }
                else
                {
                    return srcInfo.Id;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
