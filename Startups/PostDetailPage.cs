using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using SLWeek;
using SLWeek.ViewModels;
using System;
using System.Net;
using System.Windows;
using PostDetailPage = SLWeek.Views.PostDetailPage;


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
