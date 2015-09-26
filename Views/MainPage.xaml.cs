using MVVMSidekick.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SLWeek.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : MVVMPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            // add entry animations
            var transitions = new TransitionCollection { };
            var transition = new NavigationThemeTransition { };
            transitions.Add(transition);
            this.VMFrame.ContentTransitions = transitions;
        }



        public Frame RootFrame
        {
            get
            {
                return this.VMFrame;
            }
        }
    }
}
