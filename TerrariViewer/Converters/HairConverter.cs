using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TerrariViewer.Converters
{
    public class HairConverter : IValueConverter
    {
        private const string defaultHairURI = "/TerrariViewer;component/Images/Hair/Hair_1.png";
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try 
            {
                int hairID = (int)value;
                string uri = string.Format("/TerrariViewer;component/Images/Hair/Hair_{0}.png", hairID + 1);

                return new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
            }
            catch 
            {
                return new BitmapImage(new Uri(defaultHairURI, UriKind.RelativeOrAbsolute));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
