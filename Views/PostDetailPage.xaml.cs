using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MVVMSidekick.Views;
using SLWeek.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238


namespace SLWeek.Views
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

        /// <summary>
        /// 在DOM事件加载完成之后,网页加入事件为了通知页面的C#代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void webView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            //List<string> arguments = new List<string> { @"
            //        for (var i = 0; i < document.links.length; i++) { 
            //            document.links[i].onclick = function() {
            //                window.external.notify('appnews://' + this.href);
            //                return false;
            //            } 
            //        }" };

            //的DOM完成后,先获得图片列表,然后对带图片链接,加入事件处理,以便于接受页面数据
            List<string> arguments = new List<string>
           {
                "$(document).ready(function(){var urlstr='picturelist'; $(\'[href$=\".jpg\"]\').each(function() {urlstr+=this.href+'\t';}); window.external.notify(urlstr); return true;});"
           };
            await webView.InvokeScriptAsync("eval", arguments);


        }

        private async void webView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            List<string> arguments = new List<string>
            {
                "$(document).ready(function(){$(\'[href$=\".jpg\"]\').click (function() {window.external.notify(this.href); return false;});});"
            };
            await webView.InvokeScriptAsync("eval", arguments);

        }

    }
}
