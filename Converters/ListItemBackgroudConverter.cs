using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace SLWeek.Converters
{
   public  sealed class ListItemBackgroudConverter:IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, string language)
       {
           var item = value as ListViewItem;
           if (item != null)
           {
                var listView = ItemsControl.ItemsControlFromItemContainer(item);
                var index = listView.ItemContainerGenerator.IndexFromContainer(item);
                return index % 2 == 0 ? new SolidColorBrush() { Color = Colors.DarkRed } : new SolidColorBrush() { Color = Colors.LightCyan };
            }

           return null;
       }

       public object ConvertBack(object value, Type targetType, object parameter, string language)
       {
           throw new NotImplementedException();
       }
    }
}
