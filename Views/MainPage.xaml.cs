using Windows.Foundation;
using Windows.UI.ViewManagement;
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
            //设置窗口大小,以及最小窗口大小
            ApplicationView.PreferredLaunchViewSize = new Size(1200, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 250, Height = 400 });
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
