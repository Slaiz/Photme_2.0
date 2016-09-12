using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Photme_WPF.ViewModel
{
    class BmpConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Bitmap bmp;
                using (var ms = new MemoryStream((byte[])value))
                {
                    bmp = new Bitmap(ms);
                }

                return bmp;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}