
using SLWeek.ViewModels;
using MVVMSidekick.Views;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SLWeek.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PictureViewerPage : MVVMPage
    {

        public PictureViewerPage()
            : this(null)
        {
            this.InitializeComponent();
        }
        public PictureViewerPage(PictureViewerPage_Model model)
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
        
    }
}
