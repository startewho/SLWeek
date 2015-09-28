using System;
using Windows.UI;
using Windows.UI.ViewManagement;
using MVVMSidekick.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using SLWeek.Utils;


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
          //ToggleStatusBar();
        }

        private async void ToggleStatusBar()
        {
            var statusBar = StatusBar.GetForCurrentView();
            statusBar.BackgroundColor = Colors.Black;
            statusBar.BackgroundOpacity = 0.8;
            statusBar.ForegroundColor = Colors.White;
            statusBar.ProgressIndicator.Text = "loading";
            await statusBar.HideAsync();

        }


        public Frame RootFrame
        {
            get
            {
                return this.VMFrame;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void VMFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            RequestedTheme = AppSettings.Instance.CurrentTheme;
        }
    }
}
