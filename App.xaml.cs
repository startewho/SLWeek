using System;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MVVMSidekick.Startups;
using Q42.WinRT.Data;
using SLWeek.Utils;
using SLWeek.Views;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=402347&clcid=0x409

namespace SLWeek
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public  App()
        {

            InitializeComponent();
           // InitSet();
            Suspending += OnSuspending;
            Offset = 0;
          
        }
        public double Offset;

        public static async void InitNavigationConfigurationInThisAssembly()
        {
            StartupFunctions.RunAllConfig();
            await WebDataCache.Init();
        }
        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (Debugger.IsAttached)
            {
                DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            //Init MVVM-Sidekick Navigations:
            InitNavigationConfigurationInThisAssembly();


            Frame mainFrame = Window.Current.Content as Frame;

          
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (mainFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                mainFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                mainFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                
                // Place the frame in the current Window
                Window.Current.Content = mainFrame;
              
            }

         

            if (mainFrame.Content == null)
            {
                // Removes the turnstile navigation for startup.

                mainFrame.Name = "MainFrame";
                mainFrame.Navigating += OnNavigating;
                mainFrame.Navigated += OnNavigated;
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter

                if (!mainFrame.Navigate(typeof(MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

           

            // listen for back button clicks (both soft- and hardware)

            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                HardwareButtons.BackPressed += OnBackPressed;
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        private void OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            var frame = sender as Frame;
            if (frame != null) frame.RequestedTheme = AppSettings.Instance.CurrentTheme;
        }


        void OnNavigated(object sender, NavigationEventArgs e)
        {
            UpdateBackButtonVisibility();
        }
        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

       void OnBackPressed(object sender, BackPressedEventArgs e)
        {
            var mainFrame = (Frame)Window.Current.Content;
            
            if (mainFrame.CanGoBack)
            {
                e.Handled = true;
                mainFrame.GoBack();
            }
        }

        // handle software back button press
        void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            var mainFrame = (Frame)Window.Current.Content;
            
            if (mainFrame.CanGoBack)
            {
                e.Handled = true;
                mainFrame.GoBack();
            }
        }

        /// <summary>
        /// 初始化设置
        /// </summary>
        private void InitSet()
        {
            //Current.Resources.ThemeDictionaries.Clear();
            Current.RequestedTheme = AppSettings.Instance.CurrentTheme== ElementTheme.Light ? ApplicationTheme.Light : ApplicationTheme.Dark;

            // Current.Resources.MergedDictionaries.Clear();

            // 
        }

        private void UpdateBackButtonVisibility()
        {
            var mainFrame = (Frame)Window.Current.Content;

            var visibility = AppViewBackButtonVisibility.Collapsed;
            if (mainFrame.CanGoBack)
            {
                visibility = AppViewBackButtonVisibility.Visible;
            }

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = visibility;
        }
    

    }
}
