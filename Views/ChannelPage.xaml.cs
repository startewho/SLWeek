using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MVVMSidekick.Views;
using SLWeek.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SLWeek.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChannelPage : MVVMPage
    {

        public ChannelPage():base(null)
        
        {
 
            InitializeComponent();

        }
        public ChannelPage(ChannelPage_Model model):base(model)
        {
         
            InitializeComponent();
         
        }

       

        private void ListView_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var listview = sender as ListView;
            if (listview == null) return;

            var panel = (ItemsWrapGrid)(listview.ItemsPanelRoot);

            if (panel == null) throw new ArgumentNullException(nameof(panel));

            var width = e.NewSize.Width;

            var count = (int)width / 480;

            switch (count)
            {
                case 0:
                case 1:
                    panel.ItemWidth = width;
                    break;
                case 2:
                    panel.ItemWidth = width / 2;
                    break;
                case 3:
                    panel.ItemWidth = width / 3;
                    break;
                default:
                    panel.ItemWidth = width / 3;
                    break;

            }
           
        }

     
    }
}
