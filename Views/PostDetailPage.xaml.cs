﻿
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
            var vm = e.Parameter as PostDetailPage_Model;
            this.DataContext = vm;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(ChannelPage));
        }
    }
}
