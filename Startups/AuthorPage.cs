using System;
using MVVMSidekick.Views;
using SLWeek.ViewModels;
using SLWeek.Views;

namespace MVVMSidekick.Startups
{
    internal static partial class StartupFunctions
    {
        static Action AuthorPageConfig =
           CreateAndAddToAllConfig(ConfigAuthorPage);

        public static void ConfigAuthorPage()
        {
            ViewModelLocator<AuthorPage_Model>
                .Instance
                .Register(context =>
                    new AuthorPage_Model())
                .GetViewMapper()
                .MapToDefault<AuthorPage>();

        }
    }
}
