
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
using SLWeek.Source;
using SLWeek.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SLWeek.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChannelPage : MVVMPage
    {
        public ChannelPage_Model MainVM { get; set; }
        public ChannelPage():base(null)
        
        {
 
            this.InitializeComponent();
            MainVM = new ChannelPage_Model();


        }
        public ChannelPage(ChannelPage_Model model):base(model)
        {
        
         
            this.InitializeComponent();
            MainVM = new ChannelPage_Model();

        }
     

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
          
         
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

      

        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as PostModel;
            if (item != null)
            {

                var postvm = new PostDetailPage_Model(item);
                Detail.Navigate(typeof(PostDetailPage), postvm);

                //await vm.StageManager.DefaultStage.Show(postvm);
                //frame.Navigate(typeof(PostDetailPage_Model));
            }
        }
    }
}
