using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace SLWeek.Converters
{
    public   class ListViewItemStyleSelector: StyleSelector
    {
        protected override Style SelectStyleCore(System.Object item, DependencyObject container)
        {
            var style = new Style {TargetType = typeof (ListViewItem)};
            Setter backgroudSetter = new Setter {Property = Windows.UI.Xaml.Controls.Control.BackgroundProperty};
            var listview = ItemsControl.ItemsControlFromItemContainer(container) as ListView;
            if (listview != null)
            {
                var index = listview.IndexFromContainer(container);
                backgroudSetter.Value = index%2==0 ? new SolidColorBrush() {Color = Colors.Aqua} : new SolidColorBrush() { Color = Colors.Red };
            }
            style.Setters.Add(backgroudSetter);
            return style;
        }
    }
}
