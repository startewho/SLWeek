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
 
            this.InitializeComponent();

        }
        public ChannelPage(ChannelPage_Model model):base(model)
        {
         
            this.InitializeComponent();
         
        }
    }
}
