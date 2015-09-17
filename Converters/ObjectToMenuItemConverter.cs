using System;
using Windows.UI.Xaml.Data;
using SLWeek.Models;

namespace SLWeek.Converters
{
    public class ObjectToMenuItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
                return (MenuItem)value;
            return value;
        }
    }
}
