using System;
using MVVMSidekick.Views;
using SLWeek.ViewModels;
using SLWeek.Views;

namespace MVVMSidekick.Startups
{
    internal static partial class StartupFunctions
    {
        static Action PostDetailPageConfig =
           CreateAndAddToAllConfig(ConfigPostDetailPage);

        public static void ConfigPostDetailPage()
        {
            ViewModelLocator<PostDetailPage_Model>
                .Instance
                .Register(context =>
                    new PostDetailPage_Model())
                .GetViewMapper()
                .MapToDefault<PostDetailPage>();

        }
    }
}
