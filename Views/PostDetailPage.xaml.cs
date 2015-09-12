
using SLWeek.ViewModels;
using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SLWeek.Views;
using SLWeek.Models;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238


namespace SLWeek
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostDetailPage : MVVMPage
    {
    
        public PostDetailPage()
            : this(null)
        {
            this.InitializeComponent();
         
        }
        public PostDetailPage(PostDetailPage_Model model)
            : base(model)
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
     
            base.OnNavigatedTo(e);
     

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }



        private void WebView_OnNewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs e)
        {
            if (e.Referrer.Host == "www.xxxxxx.com")
            {
                var newWebView = new WebView();
                newWebView.Navigate(e.Uri);
              
                e.Handled = true;
            }

        }

   

        private void WebView_OnNavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
        
        }


    }
}
