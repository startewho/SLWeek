using MVVMSidekick.Views;
using SLWeek.ViewModels;
using System;
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
