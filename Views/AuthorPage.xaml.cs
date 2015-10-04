using Windows.UI.Xaml.Navigation;
using MVVMSidekick.Views;
using SLWeek.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SLWeek.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthorPage : MVVMPage
    {

        public AuthorPage()
            : this(null)
        {
            InitializeComponent();
        }
        public AuthorPage(AuthorPage_Model model)
            : base(model)
        {
            InitializeComponent();
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
