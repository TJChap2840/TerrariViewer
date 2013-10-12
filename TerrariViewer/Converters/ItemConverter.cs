using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using TerrariViewer.TerrariaObjects;

namespace TerrariViewer.Converters
{
    public class ItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                int val = (int)value;
                return Item.ItemDictionary[val];
            }
            catch
            {
                return Item.ItemDictionary[0];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                Item srcInfo = value as Item;
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
