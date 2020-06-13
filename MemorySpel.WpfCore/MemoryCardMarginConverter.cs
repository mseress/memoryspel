using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MemorySpel.WpfCore
{
    public class MemoryCardMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int margin)
            {
                return new Thickness(margin);
            }
            else
            {
                return new Thickness(10);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
