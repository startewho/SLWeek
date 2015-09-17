using MVVMSidekick.Views;
using SLWeek.ViewModels;
using System;
using SLWeek.Views;


namespace MVVMSidekick.Startups
{
    internal static partial class StartupFunctions
    {
        static Action PictureViewerPageConfig =
           CreateAndAddToAllConfig(ConfigPictureViewerPage);

        public static void ConfigPictureViewerPage()
        {
            ViewModelLocator<PictureViewerPage_Model>
                .Instance
                .Register(context =>
                    new PictureViewerPage_Model())
                .GetViewMapper()
                .MapToDefault<PictureViewerPage>();

        }
    }
}
