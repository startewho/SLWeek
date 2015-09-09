using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SLWeek.Utils
{
    public static class WebViewExtensions
    {
        public static string GetUriSource(WebView view)
        {
            return (string)view.GetValue(UriSourceProperty);
        }

        public static void SetUriSource(WebView view, string value)
        {
            view.SetValue(UriSourceProperty, value);
        }

        public static readonly DependencyProperty UriSourceProperty =
            DependencyProperty.RegisterAttached(
            "UriSource", typeof(string), typeof(WebViewExtensions),
            new PropertyMetadata(null, OnUriSourcePropertyChanged));

        private static  void OnUriSourcePropertyChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            var webView = sender as WebView;
            if (webView == null)
                throw new NotSupportedException();

            if (e.NewValue != null)
            {

                webView.Settings.IsJavaScriptEnabled = true;
                webView.Navigate(new Uri(e.NewValue.ToString()));
                
            }

        }





        public static string GetHtmlText(DependencyObject obj)
        {
            return (string)obj.GetValue(HtmlTextProperty);
        }

        public static void SetHtmlText(DependencyObject obj, string value)
        {
            obj.SetValue(HtmlTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for HtmlText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HtmlTextProperty =
            DependencyProperty.RegisterAttached("HtmlText", typeof(string), typeof(WebViewExtensions), new PropertyMetadata(null,OnHtmlTextSourcePropertyChanged));

        private static void OnHtmlTextSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var webView = sender as WebView;
            if (webView == null)
                throw new NotSupportedException();

            if (e.NewValue != null)
            {
                webView.Settings.IsJavaScriptEnabled = true;
                webView.Settings.IsIndexedDBEnabled = true;
                webView.NavigateToString(e.NewValue.ToString());
             
            }
        }
    }

}
