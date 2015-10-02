using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SLWeek.Utils
{
    public static class ListViewExtensions
    {
       

        #region NewSize

        public static double GetNewWidth(ListView view)
        {
            return (double)view.GetValue(NewWidthProperty);
        }

        public static void SetNewWidth(ListView view, double value)
        {
            view.SetValue(NewWidthProperty, value);
        }

        public static readonly DependencyProperty NewWidthProperty =
            DependencyProperty.RegisterAttached(
            "NewWidth", typeof(double), typeof(ListViewExtensions),
            new PropertyMetadata(null, OnWidthPropertyChanged));

        private static  void OnWidthPropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            var listview = sender as ListView;
            if (listview != null)
            {
                var panel = (ItemsWrapGrid)(listview.ItemsPanelRoot);
                var width = (double) e.NewValue;
                if (panel != null) panel.ItemWidth = width / 2;
              
            }

        }

        #endregion


      
    }

}
