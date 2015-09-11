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
using SLWeek.Views;


namespace MVVMSidekick.Startups
{
    internal static partial class StartupFunctions
    {
        static Action AuthorListPageConfig =
           CreateAndAddToAllConfig(ConfigAuthorListPage);

        public static void ConfigAuthorListPage()
        {
            ViewModelLocator<AuthorListPage_Model>
                .Instance
                .Register(context =>
                    new AuthorListPage_Model())
                .GetViewMapper()
                .MapToDefault<AuthorListPage>();

        }
    }
}
